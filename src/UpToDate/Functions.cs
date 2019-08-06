using System;

namespace UpToDate
{
    public class Functions
    {
        public void WriteMessage(string message,
    [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
    [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
    [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {// C# 5
            Console.WriteLine("message: " + message);
            Console.WriteLine("member name: " + memberName);
            Console.WriteLine("source file path: " + sourceFilePath);
            Console.WriteLine("source line number: " + sourceLineNumber);
        }

        public void OutMethod(out string name, out string surname)
        {// C# 7
            name = "Name";
            surname = "Surname";
        }

        public ref string ReturnByReference(int number, string[] names)
        {// C# 7
            return ref names[number]; // return the storage location, not the value
        }

        public ref readonly string ReturnByReferenceReadonly(int number, string[] names) // 'readonly' is the key
        {// C# 7.2
            return ref names[number]; // return the storage location, not the value
        }


        public int LocalFunctions(int a, int b)
        {
            int Sum(int a1, int b1) => a1 + b1; // Local function auto-implemented

            return Sum(a, b);
        }

        public void InParameter(in int o)// Because of 'in' o can not be modified
        {
            //o = 3;
            Console.WriteLine(o);
        }
    }
}