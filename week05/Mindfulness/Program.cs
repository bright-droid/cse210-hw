using System;

class Program
{
    static void Main(string[] args)
    {
        int userChoice = 0;

        while(userChoice != 4)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("\t1. Start breathing activity\n\t2. Start reflecting activity\n\t3. Start listing activity\n\t4. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = int.Parse(Console.ReadLine());

            Console.Clear();

            switch (userChoice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.DisplayStartingMessage();

                    breathingActivity.ShowSpinner(5);
                    
                    breathingActivity.Run();

                    breathingActivity.DisplayEndingMessage();

                    Console.Clear();
                    break;

                case 2:
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.DisplayStartingMessage();

                    reflectingActivity.ShowSpinner(5);

                    reflectingActivity.DisplayPrompt();

                    reflectingActivity.Run();

                    reflectingActivity.DisplayEndingMessage();

                    Console.Clear();
                    break;

                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.DisplayStartingMessage();

                    listingActivity.ShowSpinner(5);

                    listingActivity.Run();

                    listingActivity.DisplayEndingMessage();

                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Choose between 1 and 4 ...");
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("You Quit!");
    }
}