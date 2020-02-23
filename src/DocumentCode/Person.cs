using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Documentation
{
    /// <summary>
    /// It defines a person completely.
    /// <list type="t">
    /// <listheader>
    /// <term>Person</term>
    /// <description>Different people.</description>
    /// </listheader>
    /// <item>
    /// <term>Normal.</term>
    /// <description>Person from this planet.</description>
    /// </item>
    /// <item>
    /// <term>Alien.</term>
    /// <description>Thing from another planet.</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// This is a critical class due to his abstract aspect.
    /// </remarks>
    public class Person
    {
        /// <summary>
        /// Name used for <c>Person</c> object.
        /// It can be used as <code> Person p = new Person();</code>
        /// </summary>
        public string Name
        { get; set; }
        /// <summary>
        /// It defines a SecondName for the user, it is used normally with <c>Name</c> as 
        /// <example>
        /// <code>string s = Name + SecondName;</code>
        /// </example>
        /// </summary>
        public string SecondName
        { get; set; }
        /// <summary>
        /// The address property represents the employee's address.
        /// </summary>
        /// <value>
        /// The Address property must not contain extended chars.
        /// </value>
        public string Address
        { get; set; }
        /// <summary>
        /// Base constructor por person object.
        /// </summary>
        public Person() { }
        /// <summary>
        /// gggg
        /// </summary>
        /// <returns>DDDDD</returns>
        public string DuplicateName()
        {
            if (String.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Name is null");
            }
            return Name += Name;
        }
        /// <summary>
        /// Create a complex name.
        /// </summary>
        /// <param name="secondName">The second name to append.</param>
        public void ComplexName(string secondName)
        {
            Name = Name + " " + secondName;
        }
        /// <summary>
        /// Reverses a name.
        /// </summary>
        /// <permission cref="PermissionSet">Everyone can access this method.</permission>
        /// <returns>Reversed name.</returns>
        public string ReverseName()
        {
            return Name.Reverse().ToString();
        }
        /// <summary>
        /// Clones a person with the <paramref name="name"/> supplied.
        /// </summary>
        /// <param name="originalPerson">Person to be cloned.</param>
        /// <param name="name">new name.</param>
        public void ClonePersonWithDifferentName(Person originalPerson, string name)
        {

        }
        /// <summary>
        /// It writes a brief description about itself use 
        /// <see cref="System.Console.WriteLine(System.String)"/> to write to console.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
        /// <summary>
        /// Overrides original, <seealso cref="Person.GetHashCode()"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Overrides original.
        /// <seealso cref="Person.Equals(object)"/>.
        /// </summary>
        /// <param name="obj">Objet to compare.</param>
        /// <returns>True or false.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// Create a empty array.
        /// </summary>
        /// <typeparam name="T">Type for the array, must be <c>Person</c></typeparam>
        /// <param name="n">Array size.</param>
        /// <returns>An empty array.</returns>
        public T[] CreateArray<T>(int n) where T:Person
        {
            return null;
        }
        /// <summary>
        /// Create an empty list.
        /// </summary>
        /// <typeparam name="T">Type for the list.</typeparam>
        /// <param name="n">List size.</param>
        /// <returns>An empty list of <typeparamref name="T" />.</returns>
        public List<T> CreateList<T>(int n) where T : Person
        {
            return null;
        }
    }
}
