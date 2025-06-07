using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("1 Timothy", 6, 9);

        string scriptureText = "But they that will be rich fall into temptation and a snare, and into many foolish and hurtful lusts, which drown men in destruction and perdition.";

        Scripture scripture = new Scripture(reference, scriptureText);

        string userChoice = "";

        while (userChoice != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress enter to hide text or type 'quit' to finish: ");
            userChoice = Console.ReadLine();

            Console.Clear();

            if (userChoice == "")
            {
                scripture.HideRandomWords(1);
            }

        }

        Console.WriteLine("Goodbye!");
    }
}