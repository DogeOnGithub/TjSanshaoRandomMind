using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOutInDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable接口支持协变，即返回类型可以用指定类型的父类来代替
            IEnumerable<Derived> list = new List<Derived>();
            IEnumerable<Base> baseList = list;

            //Action接口支持逆变，即输入类型可以用指定类型的派生类来代替
            Action<Base> action = (target) => { Console.WriteLine(target.GetType().ToString()); };
            Action<Derived> derivedAction = action;
            derivedAction(new Derived());
            Console.ReadKey();
        }
    }

    class Base
    {
        public void Print()
        {
            Console.WriteLine("Base");
        }
    }

    class Derived : Base
    {
        public new void Print()
        {
            Console.WriteLine("Derived");
        }
    }
}
