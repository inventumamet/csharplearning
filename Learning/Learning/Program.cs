using System;

namespace Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            AttributePlay ap = new AttributePlay();
            ap.Print();

            LINQExample le = new LINQExample();
            le.Run();
        }
    }
}
