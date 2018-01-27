using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemo
{
    class Person
    {
        private int age;
        private string name;

        public int Age { get => age; set => age = value; }

        public void Test(ref Person person)
        {
            Console.WriteLine(person.age);
            person.Age = 44;
        }
    }
}
