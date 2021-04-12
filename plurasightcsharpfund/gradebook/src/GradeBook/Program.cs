using System;
using System.Collections.Generic;
using System.IO;

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

        private static void WriteToTerminal(string logMessage)
        {
            System.Console.WriteLine(logMessage);
        }

        static void Main(string[] args)
        {

            StreamWriter f = new StreamWriter("test.txt");
            f.WriteLine("test");
            f.Close();

            var book = new MemoryBook("book 1");
            // book.AddGrade(23.2);
            // book.AddGrade(80.5);
            // book.AddGrade(90.6);
            System.Console.WriteLine("Please enter values (or 'q' to quit):");

            for (var i = 0; i < 10; ++i) 
            {
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                else
                {
                    if (input.Length == 1)
                    {
                        try {
                            book.AddGrade(input);
                            continue;
                        }
                        catch (ArgumentException)
                        {
                            // do nothing
                        }
                    }

                    try {
                        var gradeValue = Convert.ToDouble(input);
                        book.AddGrade(gradeValue);
                    }
                    catch (FormatException ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    catch (ArgumentException ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        System.Console.WriteLine("**");
                    }
                }
            }

            FileLogger fileLogger = new FileLogger("BookLog.txt");

            Book.LogWriterDelegate log;
            log = WriteToTerminal;
            log += fileLogger.writeLineToFile;
            book.PrintStatistic(log);


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
