using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static private double Sum(double[] inputArray)
        {
            double result = 0;
            foreach (var value in inputArray) {
                result += value;
            }

            return result;
        }


        static void Main(string[] args)
        {

            var book = new Book("book 1");
            book.AddGrade(23.2);
            book.AddGrade(80.5);
            book.AddGrade(90.6);

            book.PrintStatistic();

            double[] numbers = new double[]{12.7, 10.3, 6.11};
            for (var i = 0; i < numbers.Length; ++i)
                System.Console.WriteLine($"{numbers[i]}");

            System.Console.WriteLine($"sum is {Sum(numbers)}");

            var grades = new List<double>(){12.7, 10.3, 6.11};
            grades.Add(12.5);

            System.Console.WriteLine($"sum of list is {Math.Sum(grades)}");
            System.Console.WriteLine($"average of list is {Math.Average(grades):N2}");
            

            float[] j = {1, 2, 3, 4, 5, 6, 7, 8, 9};

            double x = 12.3;
            double y = 13.6;

            Console.WriteLine($"x + y = {x+y}");
            System.Console.WriteLine();

            if (args.Length == 1) 
            {
                String name = args[0];
                Console.WriteLine($"Hello {name}!");
            }
        }
    }
}
