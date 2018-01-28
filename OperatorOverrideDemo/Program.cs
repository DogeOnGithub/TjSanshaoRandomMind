using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverrideDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Age = 11 };
            Person p2 = new Person { Age = 22 };

            Console.WriteLine((p1 + p2).Age);
            Console.ReadKey();
        }
    }

    class Person
    {
        public int Age { get; set; }

        /// <summary>
        /// 重载二元运算符+
        /// </summary>
        /// <param name="p1">左操作数</param>
        /// <param name="p2">右操作数</param>
        /// <returns>返回一个新的Person</returns>
        public static Person operator +(Person p1, Person p2)
        {
            return new Person { Age = p1.Age + p2.Age };
        }
    }
}
