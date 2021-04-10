using System.Collections.Generic;
using System;
using System.Linq;

namespace GradeBook
{
    public class Book 
    {
        public Book(string name)
        {
            gradeList = new List<double>();
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public double GetTotal()
        {
            return Math.Sum(this.gradeList);
        }

        public double GetAverage()
        {
            return Math.Average(this.gradeList);
        }

        public string GetGradeLetter()
        {
            switch (this.GetAverage())
            {
                case var avg when avg >= 90.0:
                    return "A";
                case var avg when avg >= 80.0:
                    return "B";
                case var avg when avg >= 70.0:
                    return "C";
                case var avg when avg >= 60.0:
                    return "D";
                case var avg when avg >= 50.0:
                    return "E";
                default:
                    return "F";
            }
        }

        public double GetMax()
        {
            double maxValue = double.MinValue;
            foreach (var value in this.gradeList)
            {
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
            return maxValue;
            // var query = from value in this.gradeList orderby value descending select value;
            // return query[0];
        }

        public double GetMin()
        {
            double minValue = double.MaxValue;
            foreach (var value in this.gradeList)
            {
                if (value < minValue)
                {
                    minValue = value;
                }
            }
            return minValue;
        }

        public void AddGrade(double newGrade)
        {
            if (newGrade > 100 || newGrade < 0)
            {
                throw new ArgumentException("Must enter values between 0 and 100 for new grades.");
            }
            else
            {
                this.gradeList.Add(newGrade);
            }
        }

        public void PrintStatistic()
        {
            Console.WriteLine($"Book: {name} Max grade is {this.GetMax()}");
            Console.WriteLine($"Book: {name} Min grade is {this.GetMin()}");
            Console.WriteLine($"Book: {name} Average grade is {this.GetAverage()}");
            Console.WriteLine($"Book: {name} Total grade is {this.GetTotal()}");
        }

        public Statistics GetStatistics()
        {
            var stats = new Statistics();
            stats.Average = this.GetAverage();
            stats.MaxValue = this.GetMax();
            stats.MinValue = this.GetMin();

            return stats;
        }

        // private

        private List<double> gradeList;
        private string name;
    }
}