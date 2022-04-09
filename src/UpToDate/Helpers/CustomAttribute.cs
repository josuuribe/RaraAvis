namespace UpToDate.Helpers;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class CustomAttribute : Attribute
{
    private string log;

    public CustomAttribute(string s)
    {
        this.log = s;
    }
}
