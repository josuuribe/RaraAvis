using System.Text;

namespace UpToDate.Helpers;

public record class PersonRecord
{
    public string LastName { get; }
    public string FirstName { get; }

    public PersonRecord(string first, string last) => (FirstName, LastName) = (first, last);

    public PersonRecord(PersonRecord person) => (FirstName, LastName) = (person.FirstName, person.LastName);
}

public record class TeacherRecord : PersonRecord
{
    public string Subject { get; }
    public TeacherRecord(string first, string last) : base(first, last) => Subject = string.Empty;
    public TeacherRecord(string first, string last, string sub) : base(first, last) => Subject = sub;

    public sealed override string ToString() => Subject;
}

public record Student : PersonRecord
{
    public int Level { get; set; }
    public Student(string first, string last, int level) : base(first, last) => Level = level;

    public override string ToString()
    {
        StringBuilder s = new();
        base.PrintMembers(s);
        return $"{s.ToString()} is a {base.EqualityContract}";
    }
}


public readonly record struct School(string address, int number, double distance);
