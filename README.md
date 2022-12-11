# Vending Machine console app
> Assignment 1 for Advanced Object Oriented Programming at Handelsakademin

A C# (.net6) console application for a digital vending machine.

Use `UpArrow`, `DownArrow`, `Enter` and `Backspace` to navigate.


# Docs in Swedish

## Om Applikationen
Det här är en konsolapplikation skriven i C# (.net6) som presenterar en digital varuautomat med ett utbud av läsk, choklad och energidrycker.
Utöver funktionen att navigera och köpa varor tillhandahålls också ett system där användaren innehar pengar av vissa valutor (1, 5, 10, 20, 50 och 100 kr) och kan vid köptillfället "stoppa in" dessa i maskinen för att sedan avsluta köpet och få tillbaka växel i högsta möjliga valutor.
Köpta produkter hamnar sedan i användarens ryggsäck där de kan konsumeras.

## Navigering
Applikationens input hanteras av en subklass av `InputHandler`, vid namn `MenuInputHandler`.
Denna klass använder sig av en förutbestämd enum som innehåller "godkända" tangentnamn, och en InputHandler kan sedan använde denna enum för att implementera en switch-sats och utföra olika funktionaliteter beroende på inputen.

#### InputHandler och MenuInputHandler
`MenuInputHandler` är den enda konkreta klassen för att hantera navigering i programmet, dock har InputHandler (en abstrakt grundklass) använts för att applikationen ska kunna utöka mer fler implementeringar i framtiden.
Denna uppsättning klasser tillåter `InputHandler` att läsa av att inputen är korrekt och godkänd, och sedan kan `MenuInputHandler` implementera en konkret lösning för vad som ska hända med den givna inputen.

##### Inputs
Med `MenuInputHandler` navigerar sig användaren genom applikationen genom att använda:
* Piltangenterna `Upp` och `Ned`
* `Enter` för att använda/navigera sig vidare
* `Backspace` för att avsluta/avbryta/återgå till tidigare meny.


## Produkter
Varuautomaten innehåller nio olika produkter, som i sin tur är indelade i tre olika kategorier.
Dessa kategorier finns representerade i filen `CategoryEnum` och är:
* Chocolate
* EnergyDrink
* Soda

#### Product och IProduct
`Product` är en abstrakt klass som implementerar interfacet `IProduct`.

`IProduct` innehåller två metoder:
* Buy
* Use

Implementationen av dessa i `Product` är följande:
* Buy - Skriver ut att produkten köpts, och returnerar en kopia av produkten
* Use - Skriver ut att produkten har använts.

Implementeringen av dessa är virtuella, vilket gör att subklasser kan skriva över dem om det behövs.

`Product` innehåller även variabler:'
* En statisk lista av produkter - Denna lista instansieras i MainView för att automaten ska ha tillgång till information för alla produkter.
* Name (string) - Namnet på produkten
* Description (string) - Beskrivning av produkten
* Price (int) - Priset på produkten
* ProductCategory (ProductCategories) - Produktens kategori (enum)

#### Produkter
##### Chocolate
* Snickers - 12kr
* Twix - 12kr
* Mars - 12kr

##### Energy Drinks
* Red Bull - 24kr
* Powerking - 19kr
* Monster Energy - 31kr

##### Sodas
* Coca Cola - 20kr
* Fanta - 20kr
* Sprite - 20kr

## Pengar
Pengarna som används i automaten har valutorna 1, 5, 10, 20, 50 och 100 kr.
Dessa finns alla som var sin klass under mappen User/Values, med en grundklass vid namn `Money`.

## Användaren
Applikationen är uppbyggd för att i framtiden kunna hantera flera olika användare.
Just nu finns bara möjlighet för en användare att använda varuautomaten, och därför är klassen `User` statisk, vilket tillåter användarens `Wallet` och `Backpack` att kommas åt från alla andra klasser.

#### Wallet
 Innehåller variabler och funktionalitet för att hantera användarens pengar.
Detta inkluderar även pengar som lagts in i en automat men där köpet inte verifierats ännu.

Variabler:
* Money (List<Money>) - En lista av alla olika valutor av pengar användaren har. Vid start är detta 10x 10kr, 10x 5kr och 10x 1kr.
* InputMoney (List<Money>) - En lista av alla olika valutor som matats in i automaten men där köpet inte genomförts av användaren ännu.

För vardera av dessa variabler finns en property för att se det totala värdet av alla valutor: `Balance` och `Inputbalance`.

Metoder:
* Input - Metod som tar emot en `Money` och flyttar en valuta från `Money` till `InputMoney`. Returnerar en bool för om användaren har valutan som ska flyttas eller inte.
* CompletePurchase - Kallas på när användaren godkänner köpet. Tar emot en `Product`. Printar ut info och vad som utförts. Lägger till produkten i användarens ryggsäck.
* CancelPurchase - Avbryter köpet och lägger tillbaka alla pengar från `InputMoney` till `Money`. Printar ut att köpet avbrytits.

#### Backpack
Innehåller variabler och funktionalitet för att hantera produkter köpta av användaren.
En väldigt simpel klass som innehåller en lista för alla köpta produkter, en metod för att lägga till en produkt till listan, och en metod för att använda en produkt, vilket kollar att produkten finns i ryggsäcken och den kallar sedan på produktens `Use`-metod innan den tar bort produkten från listan.

## Vyer
I mappen `Views` finns applikationens olika vyer. Dessa presenterar information för användaren beroende på hur användaren navigerar sig genom applikationen.

#### View
`View` är den abstrakta grundklassen. Den innehåller de grundläggande metoderna och variablerna för att en view ska vara funktionell.

Variablerna inkluderar:
* En lista av menyalternativ
* En inputhanterare
* Ett index (int) för det nuvarande valda menyalternativet

Metoderna inkluderar:
* `Show` som startar upp och hanterar vyn, med en kontinuerlig while-loop som gör att användaren inte lämnar vyn om hen inte explicit trycker på `Backspace`.
* `PrintMenuOptions` för att skriva ut alla menyalternativ
* `PrintVendingMachineHeader` för att skriva ut huvudheadern som finns på i de flesta views

#### Konkreta vyer
Det finns ett antal konkreta vyer som representerar var sin meny:
* `MainView` - Huvudmenyn, med alternativ för kategorier, kolla användarens pengar, och kolla vad användaren köpt. Navigerar vidare till `CategoryView`, `BackpackView` och `WalletView`.
* `CategoryView` - En vy för att visa upp produkter som är del av en viss kategori för att sedan navigera till `PurchaseView`.
* `PurchaseView` - Vyn för att köpa en viss produkt. Presenterar användarens pengar för att kunna köpa en produkt.
* `BackpackView` - Presenterar användarens "ryggsäck" där hen kan använda de produkter hen köpt.
* `WalletView` - Visar användarens "plånbok" med alla olika valutor som användaren innehar.

## Menyalternativ
Menyalternativen innehåller allting som krävs för att visa information om ett alternativ, samt vad som ska utföras när menyvalet har valts.
Variabler och metoder är väldigt lika mellan samtliga subklasser då samtliga klasser ska utföra i princip samma sak.

Variabler:
* Action (Action) - Vad som ska utföras när alternativet valts

Metoder (samtliga är virtuella):
* GetMenuOptionString - Returnerar en beskrivande sträng för menyalternativet. Tar emot en bool som indikerar på om alternativet är valt.
* Execute - Kallar på `Action`.
* AddSelected - Lägger till "==> " i början av en stringbuilder (används när `GetMenuOptionString`s bool är true).

Utöver dessa variabler har samtliga subklasser sina egna implementeringar av variabler som krävs för att de ska kunna visas i sina respektive view.

`MenuOption`s subklasser:
* CategoryOption - Används i `MainView` för att visa de olika kategorierna
* ProductOption - Används i `CategoryView` för att visa de olika produkterna
* BackpackOption - Används i `BackpackView` för att visa produkter i användarens "ryggsäck"
* MoneyOption - Används i `MoneyView` och `PurchaseView` för att visa upp användarens valutor i grupp
* CustomOption - Används då ett alternativ är unikt och endast kräver en string för att beskriva sin funktion. Kräver även en `Action` i konstruktorn då detta är unikt för varje instans.

## Util-klasser
Utöver de ovan nämnda klassern finns även ett antal utility-klasser som innehåller metoder som i vissa fall separerats från en annan klass för att en eller flera metoder i framtiden kan vara återanvändbar, eller att en metod ska användas på olika ställen i projektet.