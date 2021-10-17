using System;

namespace DynamoDBCoursera
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var dynamoOperations = new DynamoOperations();
            dynamoOperations.UploadExample();
            // dynamoOperations.ScanTable();
            dynamoOperations.QueryItem("tallie");
        }
    }
}