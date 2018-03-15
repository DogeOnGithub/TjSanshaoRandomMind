using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicObjectDemo;

namespace DynamicObjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic stringType = new StaticMemberDynamicWrapper(typeof(string));
            var str = stringType.Concat("Tj", "Sanshao");
            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
