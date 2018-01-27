using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person { Age = 22 };
            Person person2 = new Person { Age = 33 };
            person1.Test(ref person2);
            Console.WriteLine(person2.Age);
            Console.ReadKey();
        }
    }
}
