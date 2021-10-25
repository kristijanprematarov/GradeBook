namespace GradeBook.Test
{
    using System;
    using Xunit;

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        private int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMehod()
        {
            WriteLogDelegate logDelegate = ReturnMessage;//1

            logDelegate += ReturnMessage;//2
            logDelegate += IncrementCount;//3

            var result = logDelegate("Hello");

            Assert.Equal(3, count);
        }

        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        private string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Kris";
            var upper = MakeUppercase(name);

            Assert.Equal("Kris", name);
            Assert.Equal("KRIS", upper);
        }

        private string MakeUppercase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetNameDirectlyOntoObjectMemory(ref book1, "NewName");

            Assert.Equal("NewName", book1.Name);
        }

        private void GetBookSetNameDirectlyOntoObjectMemory(ref InMemoryBook inMemoryBook, string newName)
        {
            inMemoryBook = new InMemoryBook(newName);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(book1, "NewName");

            Assert.Equal("InMemoryBook 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook inMemoryBook, string newName)
        {
            inMemoryBook = new InMemoryBook(newName);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("InMemoryBook 1");
            SetName(book1, "NewName");

            Assert.Equal("NewName", book1.Name);
        }

        private void SetName(InMemoryBook inMemoryBook, string newName)
        {
            inMemoryBook.Name = newName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("InMemoryBook 1");
            var book2 = GetBook("InMemoryBook 2");

            Assert.Equal("InMemoryBook 1", book1.Name);
            Assert.Equal("InMemoryBook 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            var book1 = GetBook("InMemoryBook 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private InMemoryBook GetBook(string bookName)
        {
            return new InMemoryBook(bookName);
        }
    }
}
