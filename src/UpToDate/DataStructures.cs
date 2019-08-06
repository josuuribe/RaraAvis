using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UpToDate
{
    public class DataStructures
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DataStructures()
        {

        }

        public DataStructures(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }

        public void Tuple(string a, string b)
        {// C# 7
            var tuple = (a, b); // Unnamed tuple
            System.Console.WriteLine(tuple.a);
            System.Console.WriteLine(tuple.b);

            // C# 7.1
            var tupleNamed = (key: a, value: b); // Named tuple
            System.Console.WriteLine(tupleNamed.key);
            System.Console.WriteLine(tupleNamed.value);

            // C# 7.3
            var tupleEquality1 = (key: "1", value: "1.1");
            var tupleEquality2 = (key: "1", value: "1.1");
            System.Console.WriteLine(tupleEquality1 == tupleEquality2 ? "Equals" : "Not Equals"); // Compare values by position, both equals
        }

        public (int, double) Average(int[] values)
        {
            return (values.Length, values.Average()); // Return a tuple with two values
        }

        public void Deconstruction()
        {
            var avg = Average(new int[] { 1, 2 });
            System.Console.WriteLine($"For {avg.Item1} items the average is {avg.Item2}");
        }

        public void Deconstruct(out string firstName, out string lastName) // Magic method will be used when deconstruction
        {// It can be also an extension method
            firstName = FirstName;
            lastName = LastName;
        }

        public string CallPrivateProtected()
        {
            return Example();
        }

        private protected string Example()
        {// This method can only be called by parent in the same assembly
            return "Private protected";
        }
    }
}
