using System;
using System.Threading.Tasks;
using UpToDate.Helpers;
using static UpToDate.DataStructures;

namespace UpToDate
{
    static class Program
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
            Console.WriteLine($"Color: {expressions.ExpressionPatterns()}");
            Building p1 = new Building()
            {
                Age = 10,
                State = "Spain"
            };
            Console.WriteLine(expressions.PropertyExpression(p1));
            Console.WriteLine(Expressions.SwitchTuple("one", "second"));
            Console.WriteLine(expressions.PositionalPattern(p1));
            Console.WriteLine(expressions.ShortUsing().Age);
            await foreach (var number in Expressions.GenerateWord("z"))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine(expressions.Indexes(^1)); // The last one
            Console.WriteLine(expressions.Ranges(0..3).Length); // The first three
            Console.WriteLine(expressions.Ranges(^2..^1).Length); // The penultimate element ("Four")
            Console.WriteLine(expressions.Ranges(..).Length); // All ("One","Two","Three","Four","Five")
            Console.WriteLine(expressions.Ranges(..2).Length); // First two ("One","Two")
            Console.WriteLine(expressions.Ranges(3..).Length); // From third till end ("Four", "Five")
            Console.WriteLine(expressions.Ranges(1..4).Length); // From second till third ("Two", "Three", "Four")
            Console.WriteLine(expressions.NullCoalescenceAsignment());

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
            Console.WriteLine(functions.Father());


            System.Console.WriteLine(await Header("DataStructures"));
            DataStructures dataStructures1 = new DataStructures();
            dataStructures1.Tuple("alpha", "beta");
            DataStructures dataStructures2 = new DataStructures("John", "Doe");
            var (f, l) = dataStructures2;
            System.Console.WriteLine(f);
            System.Console.WriteLine(l);
            dataStructures1.CallPrivateProtected();
            dataStructures1.Deconstruction();
            Person person = new Person("John", "Doe");
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Surname);
            Animal animal = new Animal("Leopard", "Big");
            Console.WriteLine(animal.Genre);
            Console.WriteLine(animal.Specie);
            animal.Specie = "Unknown";
            Console.WriteLine(animal.FullString());


            Lion lion = new Lion();
            Console.WriteLine(lion.Run());
            Console.WriteLine(lion.Walk());
            IActions ilion = lion as IActions;
            Console.WriteLine(ilion.Flight(100));// It's necessary cast to ILion to get access to Flight().
            Eagle eagle = new Eagle();
            Console.WriteLine(eagle.Run());
            Console.WriteLine(eagle.Walk());
            IActions ieagle = eagle as IActions;
            IActions.SetTravel(35);
            Console.WriteLine(ieagle.Flight(10));// It's necessary cast to ILion to get access to Flight().

            System.Console.WriteLine(await Header("Extra"));
            Extra extra = new Extra();
            var a = extra.CreateWithNullName();
            Console.WriteLine(a.Name);
            var nulls = extra.NullsInParameters();
            Console.WriteLine(nulls);
            var find = extra.Find<string>(null!);
            Console.WriteLine(find);
            Person?[] people = null!;
            extra.Swap(ref people);
            Console.WriteLine(people.Length);
            string? str = null;
            if (extra.IsNullOrEmpty(str))
            {
                Console.WriteLine(str.Length);
            }
            string? versionStr = "0.0.0.0";
            extra.TryParse(versionStr, out Version version);
            Console.WriteLine(version.Major);
            CustomQueue<string> queue = new CustomQueue<string>();
            if (!queue.TryDequeue(out var result))
                Console.WriteLine(result.Length);
            string? toLower = null;
            var lower = extra.ToLower(toLower);
            Console.WriteLine(lower.Length);
            string lowerException = "As";
            extra.ThrowLowerException(lowerException);
            extra.AssertIsLower(false);

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
