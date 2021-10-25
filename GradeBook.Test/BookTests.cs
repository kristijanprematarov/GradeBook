namespace GradeBook.Test
{
    using System;
    using Xunit;

    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            //ARRANGE DATA TO ACT UPON IT => ARRANGE
            var book = new InMemoryBook("");
            book.AddGrade(77.3);
            book.AddGrade(89.1);
            book.AddGrade(90.5);

            //ACTUAL DATA => ACT
            var stats = book.GetStatistics();

            //DO A CHECK(TEST) => ASSERT
            Assert.Equal(77.3, stats.Low);
            Assert.Equal(90.5, stats.High);
            Assert.Equal(85.6, stats.Average, 1);
            Assert.Equal('B', stats.Letter);
        }
    }
}
