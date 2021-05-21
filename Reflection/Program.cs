using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=============================== reflection assembly object metadata ======================================");
            Console.WriteLine("\n");
            Console.WriteLine("Load in dll file as assembly object at run time");
            Console.WriteLine("\n");
            var assembly = System.Reflection.Assembly.LoadFile(@"E:\Google Chrome Downloads\ReflectThis.dll");
            Console.WriteLine("Get all types from assembly object");
            var types = assembly.GetTypes();
            Console.WriteLine("\n");
            Console.WriteLine("write down type name and method parameter and return type if available");
            Console.WriteLine("\n");
            Console.WriteLine("==========================================================");
            foreach (var item in types)
            {
                Console.WriteLine($"Type name:  {item.FullName}");
                if (item.GetMethods().Count() > 0)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Methods:");
                    foreach (var item2 in item.GetMethods())
                    {
                       Console.WriteLine("\n");
                       Console.WriteLine($"Return type {item2.ReturnType.FullName}");
                       Console.WriteLine("\n");
                    }
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("\n");
                }
            }
            //var item3 = item2.FirstOrDefault();
            //var item6 = item3.GetMethods().FirstOrDefault();
            //var item7 = item6.ReturnType;
            //var item4 = item3.GetMembers();
            //var item5 = item4.FirstOrDefault();

            //var item435 = default(Type);
            //foreach (var item item.GetTypes())
            //{ 
            
            //}
            //object instance = Activator.CreateInstance()
            
        }
    }
}
