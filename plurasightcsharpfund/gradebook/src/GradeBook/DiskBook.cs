using System;
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
            throw new System.NotImplementedException();
        }
    }
}