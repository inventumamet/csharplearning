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
    }
}