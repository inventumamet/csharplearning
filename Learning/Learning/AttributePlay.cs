using System;
using System.Collections.Generic;
using System.Text;

namespace Learning
{
    // Multiuse attribute.  
    [System.AttributeUsage(System.AttributeTargets.Class |
                           System.AttributeTargets.Struct,
                           AllowMultiple = true)  // Multiuse attribute.  
    ]
    public class Author : System.Attribute
    {
        string name;
        public double version;

        public Author(string name)
        {
            this.name = name;

            // Default value.  
            version = 1.0;
        }

        public string GetName()
        {
            return name;
        }
    }

    // Class with the Author attribute.  
    [Author("P. Ackerman")]
    public class FirstClass
    {
        public FirstClass() { }
    }

    class AttributePlay
    {
        public void Print()
        {
            FirstClass fc = new FirstClass();
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(typeof(FirstClass));
            foreach (System.Attribute attr in attrs)
            {
                Author a = (Author)attr;
                Console.WriteLine("attribute name is {0} and version is {1}", a.GetName(), a.version);
            }
        }
    }
}
