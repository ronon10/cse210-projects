using System;
using System.Collections.Generic;

public class Program
{
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How have I seen the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I could do one thing today, what would it be?"
    };

    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Write a new event");
            Console.WriteLine("2. Show Journal");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load the Journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose a option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[new Random().Next(prompts.Count)];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Resposta: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(new JournalEntry(prompt, response));
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("File name to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("File name to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
