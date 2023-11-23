/************************************************************************

Denna konsolapplikation är en lösning på uppgiften för Moment 3 i kursen 
DT071G och handlar om att skapa en gästbok där användaren kan se, posta 
och ta bort gästboksinlägg. Lösningen är utvecklad av Petra Ingemarsson.

************************************************************************/

// Importerar klass för att slippa upprepa "Console".
using static System.Console;

/*
Skapar en ny instans av klassen "GuestBook", tilldelar den till 
en variabel och anropar en av klassmetoderna.
*/
GuestBook guestBook = new();
guestBook.LoadPosts();

/*
Skapar en loop som håller gränssnittet igång tills programmet avslutas.
För varje iteration av loopen rensas konsolfönstret och en klassmetod
anropas för att skriva ut befintliga inlägg i gästboken. En meny med tre
alternativ presenteras och användaren uppmanas att välja ett alternativ
(1-3). Om ett ogiltigt alternativ matas in skrivs ett felmeddelande ut
och användaren får börja om från början, det vill säga en ny iteration 
av loopen startar. Vid korrekt inmatning exekveras koden för det case 
som inmatningen matchar i switch-satsen. (1) anropar klassmetoden för 
att skapa ett nytt gästboksinlägg, (2) anropar klassmetoden för att ta 
bort ett inlägg och (3) rensar konsolfönstret och avslutar programmet.
*/
while (true)
{
    Clear();
    WriteLine("----- VÄLKOMMEN TILL GÄSTBOKEN -----\n");

    guestBook.ShowPosts();

    WriteLine("\n\nVad vill du göra?\n");
    WriteLine("1. Skapa ett nytt inlägg");
    WriteLine("2. Ta bort ett inlägg");
    WriteLine("3. Avsluta\n");

    Write("Välj ett alternativ (1-3): ");
    if (int.TryParse(ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                guestBook.AddPost();
                break;
            case 2:
                guestBook.RemovePost();
                break;
            case 3:
                Clear();
                Environment.Exit(0);
                break;
            default:
                Write("\nOgiltigt alternativ! Tryck på valfri tangent för att börja om...");
                ReadKey();
                break;
        }
    }
    else
    {
        Write("\nOgiltigt alternativ! Tryck på valfri tangent för att börja om...");
        ReadKey();
    }
}