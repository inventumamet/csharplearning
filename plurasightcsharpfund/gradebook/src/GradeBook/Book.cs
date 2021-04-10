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
        public double GetTotal()
        {
            return Math.Sum(this.gradeList);
        }

        public double GetAverage()
        {
            return Math.Average(this.gradeList);
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
            this.gradeList.Add(newGrade);
        }

        public void PrintStatistic()
        {
            Console.WriteLine($"Book: {name} Max grade is {this.GetMax()}");
            Console.WriteLine($"Book: {name} Min grade is {this.GetMin()}");
            Console.WriteLine($"Book: {name} Average grade is {this.GetAverage()}");
            Console.WriteLine($"Book: {name} Total grade is {this.GetTotal()}");
        }

        // private

        private List<double> gradeList;
        private string name;
    }
}