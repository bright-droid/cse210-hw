using System.IO.Pipes;
using System.Runtime.CompilerServices;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();


    public void AddEntry()
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        Entry newEntry = new Entry(prompt, response);
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        if (_entries.Count() == 0)
        {
            Console.WriteLine("You have not saved any entries.");
        }
        
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}||{entry._promptText}||{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (_entries.Count() == 0)
        {
            Console.WriteLine("You do not have any files yet.");
        }

        _entries.Clear();

        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("||");

            if (parts.Count() == 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];

                Entry entry = new Entry(prompt, response);
                entry._date = date;
                _entries.Add(entry);
            }

        }
        Console.WriteLine($"Loaded from {filename}");
    }
}