using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
    abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual int Age { get; set; }

        public override string ToString() => $"{Name} {Surname} is {Age} years old.";

        public Person(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
