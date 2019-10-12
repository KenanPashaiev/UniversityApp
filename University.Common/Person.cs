using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace UniversityApp.Common
{
    public abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual int Age { get; set; }

        public override string ToString() => $"{Name} {Surname} is {Age} years old.";

        public Person()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Age = 0;
        }

        public Person(string name, string surname, int age) : this()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
