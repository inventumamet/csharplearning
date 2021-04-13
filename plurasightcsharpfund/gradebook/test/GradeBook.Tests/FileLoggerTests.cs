using System;
using System.IO;
using Xunit;

namespace GradeBook.Tests
{
    public class FileLoggerTests
    {

        [Fact]
        public void JustSaveSomeRandomStuff()
        {
            using StreamWriter file = new StreamWriter("WriteLines2.txt");

            file.WriteLine("hello i'm here.");
            file.Close();
        }

    }
}