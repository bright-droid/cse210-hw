using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> input = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userInput = -1;

        while (userInput != 0)
        {
            Console.Write("Enter number: ");

            string userResponse = Console.ReadLine(); 
            userInput = int.Parse(userResponse);

            if (userInput != 0)
            {
                input.Add(userInput);
            }        
        }

        //Compute the sum

        int sum = 0;
        foreach (int number in input)
        {
            sum += number;       
        }
        Console.WriteLine($"The sum is: {sum}");

        //Compute the average
        // Notice that we first cast the sum variable to be a float. Otherwise, because
        // both the sum and the count are integers, the computer will do integer division
        // and I will not get a decimal value (even though it puts the result into a float variable).

        // By making one of the variables a float first, the computer knows that it has to
        // do the floating point division, and we get the decimal value that we expect.
        float average = ((float)sum) / input.Count;
        Console.WriteLine($"The average is: {average}");

        //Find the max

        int max = input[0];

        foreach (int number in input)
        {
            if (number > max)
            {
                // if this number is greater than the max, we have
                // found the new max!
                max = number;
            }
        }

        Console.WriteLine($"The largest number is: {max}");
    }
}