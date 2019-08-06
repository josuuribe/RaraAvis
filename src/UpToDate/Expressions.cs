using System;
using System.Collections.Generic;
using System.Text;

namespace UpToDate
{
    public class Expressions
    {
        // C# 7
        public Expressions() => Console.WriteLine("Expression");

        private string name = "First";

        // C# 7 Auto properties
        public string Name
        {
            get => name;
            set => name = value;
        }

        // C# 6 Property Initializers
        public string Surname { get; set; } = "Surname";

        // C# 6
        public void WriteName() => Console.WriteLine(Name);
        public void WriteSurname() => Console.WriteLine(Surname);

        public void TernaryCondition()
        {
            var a = 10;
            var b = a > 10 ? true : false;

            Console.WriteLine(b);
        }

        public void TernaryRefCondition()
        {// C# 7.2
            var a = 10;
            var b = 3;
            var c = 6;
            ref int res = ref (a > 10) ? ref b : ref c;// It will return c (because it's a reference)

            res = -1; // Now c is -1

            Console.WriteLine(b); // It remains 3
            Console.WriteLine(c); // It is new value -1
        }

        public void NullCoalescing()
        {
            object a = null;
            object b = a ?? new string("Null!"); // Syntax sugar to check nulls, it will has a value 'null'

            Console.WriteLine(b);
        }

        public void NullCoalescingThrow()
        {// C# 7
            try
            {
                object a = null;
                object b = a ?? throw new ArgumentNullException("Object null."); // If null you can also throw an exception
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
        }

        public void NullPropagationOperator()
        {// C# 6
            object d = null;
            var a = new { A = new { B = new { C = d } } };

            Console.WriteLine($"NULL = {a?.A?.B?.C?.ToString()}"); // Eternal null propagation
        }

        public void Interpolation(decimal value)
        {// C# 6
            System.Console.WriteLine($"You called with => {value:N3}");// Format number to show only 3 decimal places
        }

        public void NameOf(string param)
        {// C# 6
            Console.WriteLine($"Var name {nameof(param)} = {param}");
        }

        public int CastInteger(string numericValue)
        {
            if (int.TryParse(numericValue, out int i))// Not necessary to declare extra var, 'i' in place
                return i;
            return -1;
        }
    }
}
