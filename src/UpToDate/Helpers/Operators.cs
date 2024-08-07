using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UpToDate.Helpers
{
    public interface IGetNext<T> where T : IGetNext<T>
    {
        static abstract T operator ++(T other);
    }

    public struct RepeatSequence : IGetNext<RepeatSequence>
    {
        private const char Ch = 'A';
        public string Text = new string(Ch, 1);

        public RepeatSequence() { }

        public static RepeatSequence operator ++(RepeatSequence other)
            => other with { Text = other.Text + Ch };

        public override string ToString() => Text;
    }


    public record Translation<T>(T XOffset, T YOffset) : IAdditiveIdentity<Translation<T>, Translation<T>>
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        public static Translation<T> AdditiveIdentity =>
            new Translation<T>(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
    }


    public record Point<T>(T X, T Y) : IAdditionOperators<Point<T>, Translation<T>, Point<T>>
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
        {
            public static Point<T> operator +(Point<T> left, Translation<T> right) =>
                left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
        }
}
