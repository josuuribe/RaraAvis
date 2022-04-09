namespace UpToDate.Demos;

internal class DemoFunction
{
    public static async Task Execute()
    {
        Console.WriteLine(await DemoHelper.Header("Function"));
        Functions functions = new Functions();
        functions.WriteContextCaller("Example");
        functions.OutMethod(out string name, out string surname);
        Console.WriteLine(name);
        Console.WriteLine(surname);
        var resAuto = functions.LocalFunctionAuto(4, 6);
        Console.WriteLine(resAuto);
        var resLocal = functions.LocalFunctionAuto(4, 6);
        Console.WriteLine(resLocal);
        ReferenceExample();
        functions.InParameter(66);
        ReferenceExampleReadonly();
        Console.WriteLine(functions.Father());
        bool b = functions.PatternMatchFunction("Abcd");
        if (b)
            Console.WriteLine("Starts with A");
        else
            Console.WriteLine("Not starts with A");
        bool validateSomethingInteresting = false;
        try
        {
            functions.Validate(validateSomethingInteresting);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void ReferenceExample()
    {
        Functions functions = new Functions();
        string[] dummies = new string[] { "John", "Doe" };
        ref var refString = ref functions.ReturnByReference(1, dummies);
        refString = "surname";
        System.Console.WriteLine(dummies[1]);
    }

    private static void ReferenceExampleReadonly()
    {
        Functions functions = new Functions();
        string[] dummies = new string[] { "John", "Doe" };
        var refString = functions.ReturnByReferenceReadonly(1, dummies);
        refString = "surname";
        System.Console.WriteLine(dummies[1]);
    }
}
