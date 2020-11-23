using System;

namespace UpToDate.Helpers
{
#pragma warning disable S3881 // "IDisposable" should be implemented correctly
    public class Building : IDisposable
#pragma warning restore S3881 // "IDisposable" should be implemented correctly
    {
        public string Name { get; init; } = "None";
        public int Age { get; set; }
        public string State { get; set; } = String.Empty;
        public void Deconstruct(out int age, out string state) // Magic method will be used when deconstruction
        {// It can be also an extension method
            age = Age;
            state = State.ToLower();
        }

        public void Dispose()
        {
            Age = 0;
        }
    }
}
