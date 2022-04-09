﻿#nullable disable

using System.Runtime.CompilerServices;

namespace UpToDate;

public class Functions
{
    public void WriteContextCaller(string messageBefore,
    [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
    [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
    [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
    {// C# 5
        Console.WriteLine("parameter: " + messageBefore);
        Console.WriteLine("caller: " + memberName);
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


    public int LocalFunctionAuto(int a, int b)
    {
        int Sum(int a1, int b1) => a1 + b1; // Local function auto-implemented

        return Sum(a, b);
    }

    public int LocalFunctionRegular(int a, int b)
    {
        int Sum(int a1, int b1) {
            return a1 + b1; // Regular function
        }
        return Sum(a, b);
    }

    public void InParameter(in int o)// Because of 'in' o can not be modified
    {
        Console.WriteLine(o);
    }

    public int Father()
    {
        int a = 1;
        int b = 2;
        return Son(a, b);

        static int Son(int c, int d) => c + d;
    }

    public bool PatternMatchFunction(string a) =>
        a[0] is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z' and not default(char));

    [ModuleInitializer]
    public static void Start()
    {
        System.Console.WriteLine("I'm the first one");
    }
    // C# 10
    public void Validate(bool condition, [CallerArgumentExpression("condition")] string? message = null)
    {
        if (!condition)
        {
            throw new InvalidOperationException($"Argument failed validation: <{message}>");
        }
    }
}
