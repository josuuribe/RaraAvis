using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpToDate.Demos;
using UpToDate.Helpers;

namespace UpToDate.Demos
{
    internal class DemoDataStructures
    {
        public static async Task Execute()
        {
            System.Console.WriteLine(await DemoHelper.Header("DataStructures"));
            DataStructures dataStructures1 = new DataStructures();
            dataStructures1.Tuple("alpha", "beta");
            DataStructures dataStructures2 = new DataStructures("John", "Doe");
            var (f, l) = dataStructures2;
            System.Console.WriteLine(f);
            System.Console.WriteLine(l);
            dataStructures1.CallPrivateProtected();
            dataStructures1.Deconstruction();
            PersonStruct person = new PersonStruct("John", "Doe");
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Surname);
            Animal animal = new Animal("Leopard", "Big");
            Console.WriteLine(animal.Genre);
            Console.WriteLine(animal.Specie);
            animal.Specie = "Unknown";
            Console.WriteLine(animal.FullString());


            Lion lion = new Lion();
            Console.WriteLine(lion.Run());
            Console.WriteLine(lion.Walk());
            IActions ilion = lion as IActions;
            Console.WriteLine(ilion.Flight(100));// It's necessary cast to ILion to get access to Flight().
            Eagle eagle = new Eagle();
            Console.WriteLine(eagle.Run());
            Console.WriteLine(eagle.Walk());
            IActions ieagle = eagle as IActions;
            IActions.SetTravel(35);
            Console.WriteLine(ieagle.Flight(10));// It's necessary cast to ILion to get access to Flight().

            PersonRecord personRecord1 = new PersonRecord("John", "Doe");
            PersonRecord personRecord2 = new PersonRecord("John", "Doe");
            if (personRecord1 == personRecord2)
                Console.WriteLine("Equals");
            else
                Console.WriteLine("Not equals");

            PersonRecord personRecordCopy = new PersonRecord(personRecord1);
            if (personRecordCopy == personRecord1)
                Console.WriteLine("Equals");
            else
                Console.WriteLine("Not equals");

            TeacherRecord teacherRecord1 = new TeacherRecord("John", "Doe");
            if (personRecord1.Equals(teacherRecord1))
                Console.WriteLine($"Equals: {teacherRecord1.ToString()}");
            else
                Console.WriteLine($"Not Equals: {teacherRecord1.ToString()}");

            Student student = new Student("Bar", "Foo", 1);
            Console.WriteLine(student.ToString());
        }
    }
}
