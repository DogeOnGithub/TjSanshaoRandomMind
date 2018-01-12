using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            foreach (var n in person)
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }

    class Person : IEnumerable<string>
    {

        private string[] _names = { "tj1", "tj2", "tj3" };

        public string[] Names { get => _names; set => _names = value; }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < Names.Length; i++)
            {
                yield return Names[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<string>)Names).GetEnumerator();
        }
    }
}
