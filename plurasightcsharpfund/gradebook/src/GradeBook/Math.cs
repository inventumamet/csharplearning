using System.Collections.Generic;

namespace GradeBook
{
    class Math
    {
        public static double Sum(List<double> inputArray)
        {
            double result = 0;
            for (var i = 0; i < inputArray.Count; ++i) {   
                result += (double)inputArray[i];
            }

            return result;
        }

        public static double Average(List<double> inputArray)
        {
            if (inputArray.Count == 0) 
            {
                return 0;
            }
            else 
            {
                return Sum(inputArray) / inputArray.Count;
            }
        }

        public static double GetMax(List<double> inputArray)
        {
            double maxValue = double.MinValue;
            foreach (var value in inputArray)
            {
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }
            return maxValue;
        }

        public static double GetMin(List<double> inputArray)
        {
            double minValue = double.MaxValue;
            foreach (var value in inputArray)
            {
                if (value < minValue)
                {
                    minValue = value;
                }
            }
            return minValue;
        }
    }
}