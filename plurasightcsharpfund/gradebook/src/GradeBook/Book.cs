using System.Collections.Generic;
using System;
using System.Linq;

namespace GradeBook
{

    public interface IBook
    {
        Statistics GetStatistics();
    }

    public abstract class Book : IBook
    {
        private string name;
        public string Name {
            get
            {
                return this.name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Must enter a non-empty string for the name.");
                }
            }
        }
        public Book(string name)
        {
            this.Name = name;
        }

        public abstract Statistics GetStatistics();
        public delegate void LogWriterDelegate(string logMessage);
    }

    public class MemoryBook : Book
    {
        public MemoryBook(string name) : base(name)
        {
            gradeList = new List<double>();
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

        public void AddGrade(string gradeLetter)
        {
            switch (gradeLetter)
            {
                case "A":
                    this.AddGrade(90);
                    break;
                case "B":
                    this.AddGrade(80);
                    break;
                case "C":
                    this.AddGrade(70);
                    break;
                case "D":
                    this.AddGrade(70);
                    break;
                case "E":
                    this.AddGrade(70);
                    break;
                case "F":
                    this.AddGrade(70);
                    break;
                default:
                    throw new ArgumentException("Unknown grade letter, please enter A,B,C,D,E or F only.");
            }
        }

        public void PrintStatistic(LogWriterDelegate writer)
        {
            writer($"Book: {this.Name} Max grade is {this.GetMax()}");
            writer($"Book: {this.Name} Min grade is {this.GetMin()}");
            writer($"Book: {this.Name} Average grade is {this.GetAverage()}");
            writer($"Book: {this.Name} Total grade is {this.GetTotal()}");
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics(this.gradeList);
            // stats.Average = this.GetAverage();
            stats.MaxValue = this.GetMax();
            stats.MinValue = this.GetMin();

            return stats;
        }

        // private

        private List<double> gradeList;

    }
}