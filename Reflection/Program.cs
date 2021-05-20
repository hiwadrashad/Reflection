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
            var item = System.Reflection.Assembly.LoadFile(@"E:\Google Chrome Downloads\ReflectThis.dll");
            List<Type> Types = new List<Type>();
            foreach (var indexitem in item.GetTypes())
            {
                Types.Add(indexitem);
            }
            var item2 = item.GetTypes();
            var item3 = item2.FirstOrDefault();
            var item6 = item3.GetMethods().FirstOrDefault();
            var item7 = item6.ReturnType;
            var item4 = item3.GetMembers();
            var item5 = item4.FirstOrDefault();

            var item435 = default(Type);

            object instance = Activator.CreateInstance()
            
        }
    }
}
