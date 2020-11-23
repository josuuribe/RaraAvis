using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpToDate.Helpers;

namespace UpToDate.Demos
{
    internal class DemoExtra
    {
        public static async Task Execute()
        {
            System.Console.WriteLine(await DemoHelper.Header("Extra"));
            Extra extra = new Extra();
            var a = extra.CreateWithNullName();
            Console.WriteLine(a.Name);
            var nulls = extra.NullsInParameters();
            Console.WriteLine(nulls);
            var find = extra.Find<string>(null!);
            Console.WriteLine(find);
            PersonStruct?[] people = null!;
            extra.Swap(ref people);
            Console.WriteLine(people.Length);
            string? str = null;
            if (extra.IsNullOrEmpty(str))
            {
                Console.WriteLine(str?.Length);
            }
            string? versionStr = "0.0.0.0";
            extra.TryParse(versionStr, out Version version);
            Console.WriteLine(version.Major);
            CustomQueue<string> queue = new CustomQueue<string>();
            if (!queue.TryDequeue(out var result))
                Console.WriteLine(result?.Length);
            string? toLower = null;
            var lower = extra.ToLower(toLower);
            Console.WriteLine(lower.Length);
            string lowerException = "As";
            try
            {
                extra.ThrowLowerException(lowerException);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine($"Exception: {ae.Message}");
            }
            extra.AssertIsLower(false);
        }
    }
}
