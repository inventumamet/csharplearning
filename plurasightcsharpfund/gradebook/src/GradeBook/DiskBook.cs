using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public string FileName
        {
            get;
            private set;
        }
        public DiskBook(string name) : base(name)
        {
            this.FileName = $"{Name}.txt";
            using (var file = new StreamWriter(this.FileName))
            {
                file.Write("");
                file.Flush();
            }
        }

        public override void AddGrade(double grade)
        {
            using (var file = File.AppendText(this.FileName))
            {
                file.WriteLine(Convert.ToString(grade));
            }
        }

        public override Statistics GetStatistics()
        {
            List<double> gradeList = ParseAllGrades(this.FileName);
            return new Statistics(gradeList);
        }

        private List<double> ParseAllGrades(string fileName)
        {
            var resultList = new List<double>();
            using (var file = File.OpenText(fileName))
            {
                string s;
                while ( (s = file.ReadLine()) != null)
                {
                    double temp = Convert.ToDouble(s);
                    resultList.Add(temp);
                }
            }
            return resultList;
        }
    }
}