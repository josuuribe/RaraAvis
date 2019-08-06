using System;
using System.Collections.Generic;
using System.Text;

namespace UpToDate
{
    public class ControlStructures
    {
        public string ConvertToStringUsingIf(object element)
        {// C# 7
            if (element is string s)
                return s.ToUpper();// Casting included in the same line
            else if (element is int i)
                return Math.Abs(i).ToString();
            else if (element is double d)
                return Math.Truncate(d).ToString();
            else
                return string.Empty;
        }

        public string ConvertToStringUsingSwitch(object element)
        {// C# 7
            switch (element)
            {// Switch case based
                case string s:
                    return s.ToUpper();
                case int i:
                    return Math.Abs(i).ToString();
                case double d:
                    return Math.Truncate(d).ToString();
                default:
                    return string.Empty;
            }
        }

        public string ConvertToStringUsingSwitchWhen(object element)
        {// C# 7
            switch (element)
            {
                case string s when s.Length > 0:
                    return s.ToUpper();
                case int i when i > 5: // Not only be integer but also greater than 5
                    return Math.Abs(i).ToString();
                case int i: // Only integer, but any integer despite it value
                    return Math.Sqrt(i).ToString();
                case double d:
                    return Math.Truncate(d).ToString();
                case var o when (o?.ToString().Length ?? 0) == 0: // You can also use var here
                    return "Empty";
                case null: // Also check with null
                    throw new ArgumentNullException(paramName: nameof(element), message: "Element must not be null");
                default:
                    return string.Empty;
            }
        }

        public void RaiseException(string code)
        {// C# 6
            try
            {
                throw new ArgumentException(code);
            }
            catch (ArgumentException ae) when (ae.Message.Contains("100"))
            {// Type and value
                System.Console.WriteLine($"Error => {ae.Message}");
            }
            catch (ArgumentException ae) when (ae.Message.Contains("200"))
            {// Type and value
                System.Console.WriteLine($"Error => {ae.Message}");
            }
            catch (ArgumentException ae)
            {// Any other ArgumentException not included before
                System.Console.WriteLine($"Error => {ae.Message}");
            }
        }
    }
}
