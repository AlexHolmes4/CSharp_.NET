using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void GradeCanOnlyBeBetween0And100()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(-10);
            book.AddGrade(110);
            book.AddGrade(10);

            //act
            var result = book.GetStatistics();

            //assert
            Assert.Equal(10, result.Average, 1);
            Assert.Equal(10, result.High, 1);
            Assert.Equal(10, result.Low, 1);
        }
        
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }
    }
}
