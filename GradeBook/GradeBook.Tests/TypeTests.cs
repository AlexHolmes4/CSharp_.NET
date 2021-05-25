using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0; 

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            // arrange
            var x = GetInt();
            SetInt(ref x);

            //assert
            Assert.Equal(42, x);


        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }


        [Fact]
        public void CSharpCanPassByRefOut()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetNewBookAndName(out book1, "New Name");

            // act

            // assert
            Assert.Equal("New Name", book1.Name);

        }
        void GetBookSetNewBookAndName(out Book book, string name)
        {
            book = new Book(name); //out param keyword means a new instance must be initalized before method ends
        }


        [Fact]
        public void CSharpCanPassByRef()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            // act

            // assert
            Assert.Equal("New Name", book1.Name);

        }
        void GetBookSetName(ref Book book, string name)
        {
            book.Name = name;
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // assert
            Assert.Equal("Book 1", book1.Name);

        }
        void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // assert
            Assert.Equal("New Name", book1.Name);
           
        }
        void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Alex";
            var upper = MakeUppercase(name);

            Assert.Equal("Alex", name);
            Assert.Equal("ALEX", upper);

        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);  
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // act

            // assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
