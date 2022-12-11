# Vending Machine console app
> Assignment 1 for Advanced Object Oriented Programming at Handelsakademin

A C# (.net6) console application for a digital vending machine.

Use `UpArrow`, `DownArrow`, `Enter` and `Backspace` to navigate.


# Docs in Swedish

## Om Applikationen
Det h�r �r en konsolapplikation skriven i C# (.net6) som presenterar en digital varuautomat med ett utbud av l�sk, choklad och energidrycker.
Ut�ver funktionen att navigera och k�pa varor tillhandah�lls ocks� ett system d�r anv�ndaren innehar pengar av vissa valutor (1, 5, 10, 20, 50 och 100 kr) och kan vid k�ptillf�llet "stoppa in" dessa i maskinen f�r att sedan avsluta k�pet och f� tillbaka v�xel i h�gsta m�jliga valutor.
K�pta produkter hamnar sedan i anv�ndarens ryggs�ck d�r de kan konsumeras.

## Navigering
Applikationens input hanteras av en subklass av `InputHandler`, vid namn `MenuInputHandler`.
Denna klass anv�nder sig av en f�rutbest�md enum som inneh�ller "godk�nda" tangentnamn, och en InputHandler kan sedan anv�nde denna enum f�r att implementera en switch-sats och utf�ra olika funktionaliteter beroende p� inputen.

#### InputHandler och MenuInputHandler
`MenuInputHandler` �r den enda konkreta klassen f�r att hantera navigering i programmet, dock har InputHandler (en abstrakt grundklass) anv�nts f�r att applikationen ska kunna ut�ka mer fler implementeringar i framtiden.
Denna upps�ttning klasser till�ter `InputHandler` att l�sa av att inputen �r korrekt och godk�nd, och sedan kan `MenuInputHandler` implementera en konkret l�sning f�r vad som ska h�nda med den givna inputen.

##### Inputs
Med `MenuInputHandler` navigerar sig anv�ndaren genom applikationen genom att anv�nda:
* Piltangenterna `Upp` och `Ned`
* `Enter` f�r att anv�nda/navigera sig vidare
* `Backspace` f�r att avsluta/avbryta/�terg� till tidigare meny.


## Produkter
Varuautomaten inneh�ller nio olika produkter, som i sin tur �r indelade i tre olika kategorier.
Dessa kategorier finns representerade i filen `CategoryEnum` och �r:
* Chocolate
* EnergyDrink
* Soda

#### Product och IProduct
`Product` �r en abstrakt klass som implementerar interfacet `IProduct`.

`IProduct` inneh�ller tv� metoder:
* Buy
* Use

Implementationen av dessa i `Product` �r f�ljande:
* Buy - Skriver ut att produkten k�pts, och returnerar en kopia av produkten
* Use - Skriver ut att produkten har anv�nts.

Implementeringen av dessa �r virtuella, vilket g�r att subklasser kan skriva �ver dem om det beh�vs.

`Product` inneh�ller �ven variabler:'
* En statisk lista av produkter - Denna lista instansieras i MainView f�r att automaten ska ha tillg�ng till information f�r alla produkter.
* Name (string) - Namnet p� produkten
* Description (string) - Beskrivning av produkten
* Price (int) - Priset p� produkten
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
Pengarna som anv�nds i automaten har valutorna 1, 5, 10, 20, 50 och 100 kr.
Dessa finns alla som var sin klass under mappen User/Values, med en grundklass vid namn `Money`.

## Anv�ndaren
Applikationen �r uppbyggd f�r att i framtiden kunna hantera flera olika anv�ndare.
Just nu finns bara m�jlighet f�r en anv�ndare att anv�nda varuautomaten, och d�rf�r �r klassen `User` statisk, vilket till�ter anv�ndarens `Wallet` och `Backpack` att kommas �t fr�n alla andra klasser.

#### Wallet
 Inneh�ller variabler och funktionalitet f�r att hantera anv�ndarens pengar.
Detta inkluderar �ven pengar som lagts in i en automat men d�r k�pet inte verifierats �nnu.

Variabler:
* Money (List<Money>) - En lista av alla olika valutor av pengar anv�ndaren har. Vid start �r detta 10x 10kr, 10x 5kr och 10x 1kr.
* InputMoney (List<Money>) - En lista av alla olika valutor som matats in i automaten men d�r k�pet inte genomf�rts av anv�ndaren �nnu.

F�r vardera av dessa variabler finns en property f�r att se det totala v�rdet av alla valutor: `Balance` och `Inputbalance`.

Metoder:
* Input - Metod som tar emot en `Money` och flyttar en valuta fr�n `Money` till `InputMoney`. Returnerar en bool f�r om anv�ndaren har valutan som ska flyttas eller inte.
* CompletePurchase - Kallas p� n�r anv�ndaren godk�nner k�pet. Tar emot en `Product`. Printar ut info och vad som utf�rts. L�gger till produkten i anv�ndarens ryggs�ck.
* CancelPurchase - Avbryter k�pet och l�gger tillbaka alla pengar fr�n `InputMoney` till `Money`. Printar ut att k�pet avbrytits.

#### Backpack
Inneh�ller variabler och funktionalitet f�r att hantera produkter k�pta av anv�ndaren.
En v�ldigt simpel klass som inneh�ller en lista f�r alla k�pta produkter, en metod f�r att l�gga till en produkt till listan, och en metod f�r att anv�nda en produkt, vilket kollar att produkten finns i ryggs�cken och den kallar sedan p� produktens `Use`-metod innan den tar bort produkten fr�n listan.

## Vyer
I mappen `Views` finns applikationens olika vyer. Dessa presenterar information f�r anv�ndaren beroende p� hur anv�ndaren navigerar sig genom applikationen.

#### View
`View` �r den abstrakta grundklassen. Den inneh�ller de grundl�ggande metoderna och variablerna f�r att en view ska vara funktionell.

Variablerna inkluderar:
* En lista av menyalternativ
* En inputhanterare
* Ett index (int) f�r det nuvarande valda menyalternativet

Metoderna inkluderar:
* `Show` som startar upp och hanterar vyn, med en kontinuerlig while-loop som g�r att anv�ndaren inte l�mnar vyn om hen inte explicit trycker p� `Backspace`.
* `PrintMenuOptions` f�r att skriva ut alla menyalternativ
* `PrintVendingMachineHeader` f�r att skriva ut huvudheadern som finns p� i de flesta views

#### Konkreta vyer
Det finns ett antal konkreta vyer som representerar var sin meny:
* `MainView` - Huvudmenyn, med alternativ f�r kategorier, kolla anv�ndarens pengar, och kolla vad anv�ndaren k�pt. Navigerar vidare till `CategoryView`, `BackpackView` och `WalletView`.
* `CategoryView` - En vy f�r att visa upp produkter som �r del av en viss kategori f�r att sedan navigera till `PurchaseView`.
* `PurchaseView` - Vyn f�r att k�pa en viss produkt. Presenterar anv�ndarens pengar f�r att kunna k�pa en produkt.
* `BackpackView` - Presenterar anv�ndarens "ryggs�ck" d�r hen kan anv�nda de produkter hen k�pt.
* `WalletView` - Visar anv�ndarens "pl�nbok" med alla olika valutor som anv�ndaren innehar.

## Menyalternativ
Menyalternativen inneh�ller allting som kr�vs f�r att visa information om ett alternativ, samt vad som ska utf�ras n�r menyvalet har valts.
Variabler och metoder �r v�ldigt lika mellan samtliga subklasser d� samtliga klasser ska utf�ra i princip samma sak.

Variabler:
* Action (Action) - Vad som ska utf�ras n�r alternativet valts

Metoder (samtliga �r virtuella):
* GetMenuOptionString - Returnerar en beskrivande str�ng f�r menyalternativet. Tar emot en bool som indikerar p� om alternativet �r valt.
* Execute - Kallar p� `Action`.
* AddSelected - L�gger till "==> " i b�rjan av en stringbuilder (anv�nds n�r `GetMenuOptionString`s bool �r true).

Ut�ver dessa variabler har samtliga subklasser sina egna implementeringar av variabler som kr�vs f�r att de ska kunna visas i sina respektive view.

`MenuOption`s subklasser:
* CategoryOption - Anv�nds i `MainView` f�r att visa de olika kategorierna
* ProductOption - Anv�nds i `CategoryView` f�r att visa de olika produkterna
* BackpackOption - Anv�nds i `BackpackView` f�r att visa produkter i anv�ndarens "ryggs�ck"
* MoneyOption - Anv�nds i `MoneyView` och `PurchaseView` f�r att visa upp anv�ndarens valutor i grupp
* CustomOption - Anv�nds d� ett alternativ �r unikt och endast kr�ver en string f�r att beskriva sin funktion. Kr�ver �ven en `Action` i konstruktorn d� detta �r unikt f�r varje instans.

## Util-klasser
Ut�ver de ovan n�mnda klassern finns �ven ett antal utility-klasser som inneh�ller metoder som i vissa fall separerats fr�n en annan klass f�r att en eller flera metoder i framtiden kan vara �teranv�ndbar, eller att en metod ska anv�ndas p� olika st�llen i projektet.