using System;

namespace CreateStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person("Tony", "Allen", 32, Person.Genders.Male);
            Console.WriteLine(p.ToString());

            Manager m = new Manager("Tony", "Allen", 32, Manager.Genders.Male, "555-555-1212", "123b");
            Console.WriteLine(m);
        }

        class Person
        {
            private readonly string firstName;
            private readonly string lastName;
            private readonly int age;
            private readonly Genders gender;

            public Person(string _firstName, string _lastName, int _age, Genders _gender)
            {
                firstName = _firstName;
                lastName = _lastName;
                age = _age;
                gender = _gender;
            }

            public override string ToString()
            {
                return firstName + " " + lastName + " (" + gender + "), age " + age;
            }

            public enum Genders : int { Male, Female };
        }
        class Manager : Person
        {
            readonly string phoneNumber;
            readonly string officeLocation;

            public Manager(string _firstName, string _lastName, int _age, Genders _gender, string _phoneNumber, string _officeLocation)
                : base(_firstName, _lastName, _age, _gender)
            {
                phoneNumber = _phoneNumber;
                officeLocation = _officeLocation;
            }

            public override string ToString()
            {
                return base.ToString() + ", " + phoneNumber + ", " + officeLocation;
            }
        }
    }
}