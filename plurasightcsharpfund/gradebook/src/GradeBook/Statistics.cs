using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Statistics
    {
        private List<double> data;
        public Statistics(List<double> inputArray)
        {
            if (inputArray == null)
            {
                throw new ArgumentException("inputArray must not be null");
            }

            this.data = inputArray;
        }
        public double Average
        {
            get
            {
                return Math.Average(this.data);
            }
            private set {}
        }
        public double MinValue;
        public double MaxValue;


    }
}