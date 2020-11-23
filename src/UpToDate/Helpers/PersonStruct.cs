namespace UpToDate.Helpers
{
    public readonly struct PersonStruct
    {
        public string Name { get; }
        public string Surname { get; }

        public PersonStruct(string name, string surName)
        {
            this.Name = name;
            this.Surname = surName;
        }
    }
}
