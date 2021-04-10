using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            var book = new Book("test book");
            book.AddGrade(12.5);
            book.AddGrade(50.8);
            book.AddGrade(100);

            Assert.Equal(100, book.GetMax());

        }
    }
}
