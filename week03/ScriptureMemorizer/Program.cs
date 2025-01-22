using System;

class Program
{
    static void Main(string[] args)
    {
        // The scripture Enos 1:8
        Reference reference = new Reference("Enos", 1, 8);
        string scriptureText = "Wherefore, it came to pass that my soul hungered; and I kneeled down before my Maker, and I cried unto him in mighty prayer and supplication for mine own soul; and all the day long did I cry unto him; yea, and when the night came I did still raise my voice high that it reached the heavens.";


        Scripture scripture = new Scripture(reference, scriptureText);

        // Loop main
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress any key to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hiden 3 words for time
        }

        Console.WriteLine("\nAll words are hidden, thank you!!");
    }
}
