using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> Entries = new List<JournalEntry>();

    public void AddEntry(JournalEntry entry)
    {
        Entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Diary saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        Entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            Entries.Add(new JournalEntry(parts[1], parts[2]) { Date = parts[0] });
        }
        Console.WriteLine("Diary loaded successfully.");
    }
}
