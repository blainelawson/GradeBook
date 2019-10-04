using System;
using Xunit;

namespace GradeBook.Tests
{
    public class UnitTest1
    {
        [Fact] // <---this is an attribute in the test 
               //     (a little piece of data attached to what follows)
        public void Test1()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average);
            Assert.Equal(90.6, result.High);
            Assert.Equal(77.3, result.Low);            
        }
    }
}
