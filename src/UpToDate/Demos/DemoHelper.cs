namespace UpToDate.Demos;internal static class DemoHelper
{
    public static Task<string> Header(string caption)
    {
        return Task<string>.Factory.StartNew(() => $"\n\n{"*",-7} {caption} {"*",7}");
    }
}
