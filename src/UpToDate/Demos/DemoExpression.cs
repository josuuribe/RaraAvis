using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpToDate.Helpers;

namespace UpToDate.Demos
{
    internal class DemoExpression
    {
        public static async Task Execute()
        {
            System.Console.WriteLine(await DemoHelper.Header("Expression"));
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

            Building b = new () { Age = 50, Name = "Chrysler", State = "USA" };
            b.State = "New name";
            //b.Name = "11";

            if (expressions.IsNull(new()) is null)
                Console.WriteLine("Is null");
            else
                Console.WriteLine("Is not null");
        }
    }
}
