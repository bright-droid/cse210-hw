using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();
        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // alternatively using Sum() function in c#
        // int sum = numbers.Sum();
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // alternatively using Average() funtion in c#
        // double average = numbers.Average();

        // By making one of the variables a float first, 
        // the computer knows that it has to do the floating point division, 
        // and we get the decimal value that we expect.

        // So we first cast the sum variable to be a float.Otherwise, because
        // both the sum and the count are integers, the computer will do 
        // integer division and I will not get a decimal value
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        //alternatively using Max() function in c#
        //int max = numbers.Max();

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                //if this number is greater than the max, we have found
                //the new max!
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

    }
}