/*
Importerar klass för att slippa upprepa "Console" och namespace för 
att hantera konvertering mellan JSON och objekt.
*/
using static System.Console;
using System.Text.Json;

// Skapar intern klass som hanterar gästboksinlägg.
internal class ManagePosts
{
    /* 
    Privat fält som kan lagra en lista med inlägg samt en konstruktor 
    som initierar en ny instans av listan.
    */
    private List<IndividualPost> Posts;

    public ManagePosts()
    {
        Posts = new List<IndividualPost>();
    }

    /*
    Metod för att läsa ut och deserialisera innehåll från en JSON-fil 
    till listan med inlägg, förutsatt att JSON-filen exixterar.
    */
    public void LoadPosts()
    {
        if (File.Exists("guestbook.json"))
        {
            string json = File.ReadAllText("guestbook.json");
            Posts = JsonSerializer.Deserialize<List<IndividualPost>>(json)!;
        }
    }

    /*
    Metod för att skriva ut befintliga inlägg till konsolen med index, 
    författare och innehåll för respektive inlägg. Om antalet inlägg i
    listan är noll skrivs ett meddelande ut istället.
    */
    public void ShowPosts()
    {
        WriteLine("\nBefintliga inlägg:\n");

        if (Posts.Count == 0)
        {
            WriteLine("Det finns inga inlägg att visa än...");
        }

        for (int i = 0; i < Posts.Count; i++)
        {
            WriteLine($"    [{i}] {Posts[i].Author} - {Posts[i].Content}");
        }
    }

    /*
    Metod för att lägga till ett nytt inlägg i gästboken. Användaren 
    måste ange sitt namn och skriva ett innehåll till inlägget, annars 
    skrivs felmeddelanden ut och metoden avbryts. Vid korrekt ifyllda
    fält skapas ett nytt objekt som representerar ett enskilt inlägg. 
    Objektet läggs till i listan med inlägg och metoden för att spara
    listan med inlägg anropas.
    */
    public void AddPost()
    {
        Write("\nAnge ditt namn: ");
        string author = ReadLine()!;

        if (string.IsNullOrWhiteSpace(author))
        {
            Write("\nOgiltigt namn! Tryck på valfri tangent för att börja om...");
            return;
        }

        Write("Skriv ditt inlägg: ");
        string content = ReadLine()!;

        if (string.IsNullOrWhiteSpace(content))
        {
            Write("\nOgiltigt inlägg! Tryck på valfri tangent för att börja om...");
            return;
        }

        Posts.Add(new IndividualPost { Author = author, Content = content });
        SavePosts();
        Write("\nTryck på valfri tangent för att uppdatera befintliga inlägg...");
    }

    /*
    Metod för att serialisera listan med inlägg till en JSON-sträng 
    och spara den till en JSON-fil.
    */
    public void SavePosts()
    {
        string json = JsonSerializer.Serialize(Posts);
        File.WriteAllText("guestbook.json", json);
    }

    /*
    Metod för att ta bort ett inlägg från gästboken. Om det inte finns några 
    befintliga inlägg skrivs ett meddelande ut och metoden avbryts. I annat 
    fall måste användaren ange ett giltigt index för det inlägg som ska tas 
    bort, annars skrivs ett felmeddelande ut och metoden avbryts. Vid korrekt 
    angivet index tas inlägget bort från listan med inlägg och metoden för 
    att spara listan med inlägg anropas.
    */
    public void RemovePost()
    {
        if (Posts.Count == 0)
        {
            Write("\nDet finns inga inlägg att ta bort. Tryck på valfri tangent för att välja ett annat alternativ...");
            return;
        }

        Write("\nAnge index för det inlägg som ska tas bort: ");
        if (int.TryParse(ReadLine(), out int index))
        {
            if (index >= 0 && index < Posts.Count)
            {
                Posts.RemoveAt(index);
                SavePosts();
                Write("\nTryck på valfri tangent för att uppdatera befintliga inlägg...");
            }
            else
            {
                Write("\nOgiltigt index! Tryck på valfri tangent för att börja om...");
            }
        }
        else
        {
            Write("\nOgiltigt index! Tryck på valfri tangent för att börja om...");
            return;
        }
    }
}
