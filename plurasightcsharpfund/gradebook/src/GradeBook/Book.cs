using System.Collections.Generic;
using System;
using System.Linq;

namespace GradeBook
{

    public interface IBook
    {
        Statistics GetStatistics();
        void AddGrade(double grade);
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
        public abstract void AddGrade(double grade);

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

        public override void  AddGrade(double grade)
        {
            if (grade > 100 || grade < 0)
            {
                throw new ArgumentException("Must enter values between 0 and 100 for new grades.");
            }
            else
            {
                this.gradeList.Add(grade);
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
            var stats = this.GetStatistics();
            writer($"Book: {this.Name} Max grade is {stats.MaxValue}");
            writer($"Book: {this.Name} Min grade is {stats.MinValue}");
            writer($"Book: {this.Name} Average grade is {stats.Average}");
            writer($"Book: {this.Name} Total grade is {stats.Total}");
        }

        public override Statistics GetStatistics()
        {
            return new Statistics(this.gradeList);
        }
        // private

        private List<double> gradeList;

    }
}