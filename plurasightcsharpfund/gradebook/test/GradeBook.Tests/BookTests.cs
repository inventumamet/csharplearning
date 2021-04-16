using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void TestGradeLetter()
        {
            var book = new MemoryBook("grade letter book");
            book.AddGrade(100);
            book.AddGrade(90);
            book.AddGrade(95);

            Assert.Equal("A", book.GetGradeLetter());
        }

        [Fact]
        public void TestBook()
        {
            var book = new MemoryBook("test book");
            book.AddGrade(12.5);
            book.AddGrade(50.8);
            book.AddGrade(100);

            Assert.Equal(100, book.GetStatistics().MaxValue);

        }

        [Fact]
        public void TestGetStatistics()
        {
            var book = new MemoryBook("test stats");
            book.AddGrade(12.5);
            book.AddGrade(50.8);
            book.AddGrade(100);

            var stat = book.GetStatistics();
            Assert.Equal(100, stat.MaxValue);
            Assert.Equal(12.5, stat.MinValue);
            Assert.Equal(54.43, stat.Average, 2);

        }
    }
}
