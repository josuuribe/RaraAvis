using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;


namespace UpToDate.Helpers
{
    public class CustomQueue<T>
    {
        private readonly Queue<T> queue = new Queue<T>();
        // 'result' could be null if we couldn't Dequeue it.
        public bool TryDequeue([MaybeNullWhen(false)] out T result)
        {
            result = queue.Dequeue();
            return result != null;
        }
    }
}
