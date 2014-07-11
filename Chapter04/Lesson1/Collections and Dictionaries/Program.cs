using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_and_Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {

            #region ArrayList

            ArrayList al = new ArrayList();
            al.Add("Hello");
            al.Add("World");
            al.Add(5);
            al.Add(new FileStream("delemete", FileMode.Create));
            Console.WriteLine("The array has " + al.Count + " items:");
            foreach (object s in al)
                Console.WriteLine(s.ToString());

            ArrayList al1 = new ArrayList();
            al1.Add("Hello");
            al1.Add("World");
            al1.Add("this");
            al1.Add("is");
            al1.Add("a");
            al1.Add("test");
            al1.Remove("test");
            al1.Insert(4, "not");
            al1.Sort();

            foreach (object s in al1)
                Console.WriteLine(s.ToString());



            ArrayList al2 = new ArrayList();
            al2.AddRange(new string[] { "Hello", "world", "this", "is", "a", "test" });
            al2.Sort(new reverseSort());
            foreach (object s in al2)
                Console.WriteLine(s.ToString());


            ArrayList al3 = new ArrayList();
            al3.AddRange(new string[] { "Hello", "world", "this", "is", "a", "test" });
            Console.WriteLine(al3.BinarySearch("this"));

            #endregion

            #region Queue and Stack

            //FIFO
            Queue q = new Queue();
            q.Enqueue("Hello");
            q.Enqueue("world");
            q.Enqueue("just testing");
            Console.WriteLine("Queue demonstration:");
            for (int i = 1; i <= 3; i++)
                Console.WriteLine(q.Dequeue().ToString());

            //LIFO
            Stack s1 = new Stack();
            s1.Push("Hello");
            s1.Push("world");
            s1.Push("just testing");
            Console.WriteLine("Stack demonstration:");
            for (int i = 1; i <= 3; i++)
                Console.WriteLine(s1.Pop().ToString());

            #endregion

            #region Collections

            //A dictionary optimized for a small list of objects with fewer than 10 items
            ListDictionary ld = new ListDictionary();

            //A dictionary that uses a ListDictionary for storage when the number of items is small and automatically switches to a Hashtable as the list grows
            HybridDictionary hd = new HybridDictionary();

            //Both the key and the value can be any object. SortedList is sorted automatically by the key.
            SortedList sl = new SortedList();
            sl.Add("Stack", "Represents a LIFO collection of objects.");
            sl.Add("Queue", "Represents a FIFO collection of objects.");
            sl.Add("SortedList", "Represents a collection of key/value pairs.");
            foreach (DictionaryEntry de in sl)
                Console.WriteLine(de.Value);

            Console.WriteLine(sl["Queue"]);
            Console.WriteLine(sl.GetByIndex(0));

            //A dictionary of name/value pairs of strings that allows retrieval by name or index
            NameValueCollection sl1 = new NameValueCollection();
            sl1.Add("Stack", "Represents a LIFO collection of objects.");
            sl1.Add("Stack", "A pile of pancakes.");
            sl1.Add("Queue", "Represents a FIFO collection of objects.");
            sl1.Add("Queue", "In England, a line.");
            sl1.Add("SortedList", "Represents a collection of key/value pairs.");

            foreach (string s in sl1.GetValues(0))
                Console.WriteLine(s);

            foreach (string s in sl1.GetValues("Queue"))
                Console.WriteLine(s);

            #endregion
        }
        public class reverseSort : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(y, x));
            }
        }
    }
}

