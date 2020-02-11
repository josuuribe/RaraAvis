using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UpToDate.Helpers;

namespace UpToDate
{
    internal class Extra
    {

        public Sorcerer<float, string> CreateWithNullName()
        {
            var sorcerer = new Sorcerer<float, string>();
            sorcerer.Name = null;
            return sorcerer;
        }

        public string NullsInParameters()
        {
            var sorcerer = new Sorcerer<float, string>();
            Person? p = null;
            sorcerer.LowerName(ref p);
            return p.Value.Name;
        }

        [return: MaybeNull]
        public Z Find<Z>(Z s)
        {
            Z z = default(Z);
            return s!.GetHashCode() > 100 ? s : z;
        }

        public void Swap<Z>([NotNull]ref Z[]? z)
            where Z : new()
        {
            if (z is null)
            {
                z = new Z[] { new Z() };
            }
        }

        public bool IsNullOrEmpty([NotNullWhen(false)] string? value)
        {
            return String.IsNullOrEmpty(value);
        }

        public bool TryParse(string? input, [NotNullWhen(true)]out Version? version)
        {
            if (!String.IsNullOrEmpty(input))
            {
                version = new Version(input);
                return true;
            }
            version = new Version("0.0.0.0");
            return false;
        }

        [return: NotNullIfNotNull("s")]
        public string? ToLower(string? s)
        {
            if (String.IsNullOrEmpty(s))
                return string.Empty;
            return s.ToLower();
        }

        [DoesNotReturn]
        public void ThrowLowerException(string s)
        {
            throw new ArgumentException(s);
        }

        public void AssertIsLower([DoesNotReturnIf(false)] bool s)
        {
            if (s)
                throw new ArgumentException("Lower string");
        }
    }
}
