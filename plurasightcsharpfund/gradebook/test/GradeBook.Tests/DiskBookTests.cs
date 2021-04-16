using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace GradeBook.Tests
{
    public class DiskBookTests
    {

        [Fact]
        public void WriteToDisk()
        {
            var book = new DiskBook("testbook");
            book.AddGrade(5.2);
            book.AddGrade(17.5);


            List<string> expected_lines = new List<string>();

            using (var file = new StreamReader("testbook.txt"))
            {
                while (true) {
                    string line = file.ReadLine();
                    if (line != null)
                    {
                        expected_lines.Add(line);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Assert.Equal(2, expected_lines.Count);
            Assert.Equal("5.2", expected_lines[0]);
            Assert.Equal("17.5", expected_lines[1]);

            var stats = book.GetStatistics();
            Assert.Equal(17.5, stats.MaxValue);
            Assert.Equal(5.2, stats.MinValue);
            Assert.Equal(22.7, stats.Total);
            Assert.Equal(11.35, stats.Average);

            File.Delete("testbook.txt");
        }

    }
}