namespace UpToDate.Helpers
{
    public struct Animal
    {
        private string specie;
        public string Genre { get; set; }
        public string Specie
        {
            get
            {
                return specie.ToLower();
            }
            set
            {
                specie = value;
            }
        }

        public Animal(string genre, string specie)
        {
            this.Genre = genre;
            this.specie = specie;
        }

        public readonly string FullString()
        {
            return $"{Genre} -> {Specie}";
        }
    }
    public interface IActions
    {
        private static int targetDistance = 0;
        public static void SetTravel(int travel)
        {
            if (travel > 10)
                targetDistance = 20;
            else
                targetDistance = 30;
        }

        public double Walk();

        public double Run();
        /// <summary>
        /// Default implementation if other already existing classes have an older version.
        /// </summary>
        public double Flight(int miles) => DefaultFlight(this);

        protected static double DefaultFlight(IActions actions)
        {
            return 10 * targetDistance;
        }
    }
    public class Lion : IActions
    {
        public double Run()
        {
            return 2;
        }

        public double Walk()
        {
            return 1;
        }

        public double Flight(int miles)
        {
            return 0;
        }
    }
    public class Eagle : IActions
    {
        public double Run()
        {
            return 0;
        }

        public double Walk()
        {
            return 1;
        }

        double IActions.Flight(int miles) // This must append interface name IActions and without access modifiers.
        {
            return 10 * miles;
        }
    }
}
