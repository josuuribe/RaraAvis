namespace UpToDate.Helpers
{
    public readonly struct Person
    {
        public string Name { get; }
        public string Surname { get; }

        public Person(string name, string surName)
        {
            this.Name = name;
            this.Surname = surName;
        }
    }
}
