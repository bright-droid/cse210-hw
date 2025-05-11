using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.Write("What is the magic number? ");
        // int userNumber = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int userNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != userNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > userNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < userNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

        }
    }
}