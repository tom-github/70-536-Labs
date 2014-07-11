using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Collections
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Generic SortedList<T,U> Collection

            SortedList<string, int> sl = new SortedList<string, int>();
            sl.Add("One", 1);
            sl.Add("Two", 2);
            sl.Add("Three", 3);
            foreach (int i in sl.Values)
                Console.WriteLine(i.ToString());

            #endregion

            #region Using Generics with Custom Classes

            SortedList<string, PersonComparer> sl1 = new SortedList<string, PersonComparer>();
            sl1.Add("One", new PersonComparer("Mark", "Hanson"));
            sl1.Add("Two", new PersonComparer("Kim", "Akers"));
            sl1.Add("Three", new PersonComparer("Zsolt", "Ambrus"));

            foreach (PersonComparer p in sl1.Values)
                Console.WriteLine(p.ToString());

            #endregion

            #region Generic Queue<T> and Stack<T> Collections

            Queue<Person> q = new Queue<Person>();
            q.Enqueue(new Person("Mark", "Hanson"));
            q.Enqueue(new Person("Kim", "Akers"));
            q.Enqueue(new Person("Zsolt", "Ambrus"));
            Console.WriteLine("Queue demonstration:");
            for (int i = 1; i <= 3; i++)
                Console.WriteLine(q.Dequeue().ToString());

            Stack<Person> s = new Stack<Person>();
            s.Push(new Person("Mark", "Hanson"));
            s.Push(new Person("Kim", "Akers"));
            s.Push(new Person("Zsolt", "Ambrus"));
            Console.WriteLine("Stack demonstration:");
            for (int i = 1; i <= 3; i++)
                Console.WriteLine(s.Pop().ToString());

            #endregion

            #region Generic List<T> Collection

            List<PersonComparer> l = new List<PersonComparer>();
            l.Add(new PersonComparer("Mark", "Hanson"));
            l.Add(new PersonComparer("Kim", "Akers"));
            l.Add(new PersonComparer("Zsolt", "Ambrus"));
            l.Sort();
            foreach (PersonComparer p in l)
                Console.WriteLine(p.ToString());

            #endregion
        }

        public class Person
        {
            string firstName;
            string lastName;

            public Person(string _firstName, string _lastName)
            {
                firstName = _firstName;
                lastName = _lastName;
            }

            override public string ToString()
            {
                return firstName + " " + lastName;
            }
        }

        public class PersonComparer : IComparable
        {
            string firstName;
            string lastName;

            public int CompareTo(object obj)
            {
                PersonComparer otherPerson = (PersonComparer)obj;
                if (this.lastName != otherPerson.lastName)
                    return this.lastName.CompareTo(otherPerson.lastName);
                else
                    return this.firstName.CompareTo(otherPerson.firstName);
            }
            public PersonComparer(string _firstName, string _lastName)
            {
                firstName = _firstName;
                lastName = _lastName;
            }
            override public string ToString()
            {
                return firstName + " " + lastName;
            }
        }
    }
}
