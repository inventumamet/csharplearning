using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void CanSetNameWhenPassByReference()
        {

            var book1 = GetBook("Book 1");
            SetBookName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetBookName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);

        }

        [Fact]
        public void TwoVarsCanReferenceTheSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private Book GetBook(string name)
        {
            return new MemoryBook(name);
        }
    }
}
