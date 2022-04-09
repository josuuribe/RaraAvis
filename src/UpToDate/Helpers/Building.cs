namespace UpToDate.Helpers;

public class Name
{
    public string FirstName { get; set; } = "None";
    public string LastName { get; set; }
}

#pragma warning disable S3881 // "IDisposable" should be implemented correctly
public class Building : IDisposable
#pragma warning restore S3881 // "IDisposable" should be implemented correctly
{
    public Name Name { get; init; } = new Name();
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
