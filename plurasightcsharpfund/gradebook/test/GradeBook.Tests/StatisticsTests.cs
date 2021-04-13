using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class StatisticsTests
    {
        [Fact]
        public void CanGetAverageButCannotSetAverage()
        {
            var inputArray = new List<double>{1,2,3,4,5};
            var stat = new Statistics(inputArray);

            Assert.Equal(3, stat.Average);
        }

        [Fact]
        public void CannotSetDataInputToNull()
        {
            List<double> inputArray = null;
            var ex =  Assert.Throws<ArgumentException>( 
                () => 
                    {
                        var stat = new Statistics(inputArray);
                    }
                );

            Assert.Equal("inputArray must not be null", ex.Message);
        }
    }
}