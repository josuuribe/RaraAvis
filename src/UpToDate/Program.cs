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
            expressions.Discard("5");
            System.Console.WriteLine(expressions.ReturnDiscard(9.5));
            Console.WriteLine(expressions.ConvertUsingIf("Element"));
            Console.WriteLine(expressions.ConvertUsingIf(5));
            Console.WriteLine(expressions.ConvertUsingIf(4.98));
            Console.WriteLine(expressions.ConvertToStringUsingSwitch("Element"));
            Console.WriteLine(expressions.ConvertToStringUsingSwitch(5));
            Console.WriteLine(expressions.ConvertToStringUsingSwitch(4.98));
            Console.WriteLine(expressions.ConvertToStringUsingSwitchWhen("Element"));
            Console.WriteLine(expressions.ConvertToStringUsingSwitchWhen(6));
            Console.WriteLine(expressions.ConvertToStringUsingSwitchWhen(4));
            Console.WriteLine(expressions.ConvertToStringUsingSwitchWhen(4.98));
            Console.WriteLine(expressions.ConvertToStringUsingSwitchWhen(string.Empty));
            expressions.RaiseException("100");



            Console.WriteLine(await Header("Function"));
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



            System.Console.WriteLine(await Header("DataStructures"));
            DataStructures dataStructures1 = new DataStructures();
            dataStructures1.Tuple("alpha", "beta");
            DataStructures dataStructures2 = new DataStructures("John", "Doe");
            var (f, l) = dataStructures2;
            System.Console.WriteLine(f);
            System.Console.WriteLine(l);
            dataStructures1.CallPrivateProtected();
            dataStructures1.Deconstruction();
            DataStructures.Person person = new DataStructures.Person("John", "Doe");
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Surname);
            DataStructures.Animal animal = new DataStructures.Animal("Leopard", "Big");
            Console.WriteLine(animal.Genre);
            Console.WriteLine(animal.Specie);
            animal.Specie = "Unknown";
            Console.WriteLine(animal.FullString());
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
