using System.Diagnostics.CodeAnalysis;

namespace UpToDate.Helpers;

public interface ISchool<in T, out U>
    where T : notnull
    where U : notnull
{
    U Cast(T input);
}

public class Sorcerer<T, U> : ISchool<T, U>
    where T : notnull
    where U : class
{
    public int Id { get; set; }
    private string name = string.Empty;

    public U? Out { get; set; }

    [AllowNull]
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value ?? string.Empty;
        }
    }
    public U Cast(T input)
    {
        return (input as U)!;
    }



    public string LowerName([DisallowNull]ref PersonStruct? person)
    {
        person = null;
        return "Cleared";
    }
}
