namespace UpToDate.Helpers;

public readonly struct PersonStruct
{
    public string Name { get; }
    public string Surname { get; } = "Goodbye";

    public PersonStruct()
    {
        Name = "Hello";
    }

    public PersonStruct(string name, string surName)
    {
        this.Name = name;
        this.Surname = surName;
    }

    public override string ToString() => $"{Name} ({Surname})";
}

public struct Address
{
    public string Street;
    public int Number;
    public double Distance;

    public override string ToString() => $"{Street} ({Number}) in {Distance}";
}
