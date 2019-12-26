#nullable disable

using System;
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

            Console.WriteLine(tuple.a);
            Console.WriteLine(tuple.b);

            // C# 7.1
            var tupleNamed = (key: a, value: b); // Named tuple
            Console.WriteLine(tupleNamed.key);
            Console.WriteLine(tupleNamed.value);

            // C# 7.3
            var tupleEquality1 = (key: "1", value: "1.1");
            var tupleEquality2 = (value: "1.1", key: "1");
            Console.WriteLine(tupleEquality1 == tupleEquality2 ? "Equals" : "Not Equals"); // Compare values by position, both equals
        }

        public (int, double) Average(int[] values)
        {
            return (values.Length, values.Average()); // Return a tuple with two values
        }

        public void Deconstruction()
        {
            var items = Average(new int[] { 1, 2 });
            System.Console.WriteLine($"For {items.Item1} elements the average is {items.Item2}");
        }

        public void Deconstruct(out string firstName, out string lastName) // Magic method will be used when deconstruction
        {// It can be also an extension method
            firstName = FirstName.ToLower();
            lastName = LastName.ToLower();
        }

        public string CallPrivateProtected()
        {
            return Example();
        }

        private protected string Example()
        {// This method can only be called by parent in the same assembly
            return "Private protected".ToLower();
        }
    }
}
