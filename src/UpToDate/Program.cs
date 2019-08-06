using System;
using System.Threading.Tasks;

namespace UpToDate
{
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine(await Header("Expression"));
            Expressions expressions = new Expressions();
            expressions.TernaryCondition();
            expressions.TernaryRefCondition();
            expressions.NullCoalescing();
            expressions.NullCoalescingThrow();
            expressions.WriteName();
            expressions.Name = "New name";
            expressions.WriteName();
            expressions.NullPropagationOperator();
            expressions.Interpolation(100.435678M);
            expressions.NameOf("Ok");



            System.Console.WriteLine(await Header("Function"));
            Functions functions = new Functions();
            functions.WriteMessage("Ejemplo");
            string name = "John";
            string surname = "Doe";
            functions.OutMethod(out name, out surname);
            System.Console.WriteLine(name);
            System.Console.WriteLine(surname);
            ReferenceExample();
            functions.InParameter(66);
            ReferenceExampleReadonly();



            System.Console.WriteLine(await Header("DataStructures"));
            DataStructures dataStructures1 = new DataStructures();
            dataStructures1.Tuple("alpha", "beta");
            DataStructures dataStructures2 = new DataStructures("John", "Doe");
            var (first, last) = dataStructures2;
            System.Console.WriteLine(first);
            System.Console.WriteLine(last);
            dataStructures1.CallPrivateProtected();



            System.Console.WriteLine(await Header("ControlStructures"));
            ControlStructures structureControl = new ControlStructures();
            Console.WriteLine(structureControl.ConvertToStringUsingIf("Element"));
            Console.WriteLine(structureControl.ConvertToStringUsingIf(5));
            Console.WriteLine(structureControl.ConvertToStringUsingIf(4.98));
            Console.WriteLine(structureControl.ConvertToStringUsingSwitch("Element"));
            Console.WriteLine(structureControl.ConvertToStringUsingSwitch(5));
            Console.WriteLine(structureControl.ConvertToStringUsingSwitch(4.98));
            Console.WriteLine(structureControl.ConvertToStringUsingSwitchWhen("Element"));
            Console.WriteLine(structureControl.ConvertToStringUsingSwitchWhen(6));
            Console.WriteLine(structureControl.ConvertToStringUsingSwitchWhen(4));
            Console.WriteLine(structureControl.ConvertToStringUsingSwitchWhen(4.98));
            Console.WriteLine(structureControl.ConvertToStringUsingSwitchWhen(string.Empty));
            structureControl.RaiseException("100");
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

        private static Task<string> Header(string caption)
        {
            return Task<string>.Factory.StartNew(() => $"\n\n{"*",-7} {caption} {"*",7}");
        }
    }
}
