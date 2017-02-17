using System;

namespace Stats.Net.Tests.TestClasses
{
    public sealed class Person : IComparable<Person>
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int CompareTo(Person other)
        {
            if (Name == other.Name)
            {
                return Age.CompareTo(other.Age);
            }
            return Name.CompareTo(other.Name);
        }

    }
}