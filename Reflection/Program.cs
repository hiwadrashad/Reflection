using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    public class Program
    {
        #region metadata
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
            Console.WriteLine("write down all members and their name and type");
            Console.WriteLine("\n");
            Console.WriteLine("write down type name and method parameter and return type if available");
            Console.WriteLine("\n");
            Console.WriteLine("==========================================================");
            foreach (var item in types)
            {
                Console.WriteLine($"Type name: {item.FullName}");
                if (item.GetMembers().Count() > 0)
                {
                    foreach (var item4 in item.GetMembers())
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine($"Member name: {item4.Name}");
                        Console.WriteLine("\n");
                        Console.WriteLine($"Member type: {item4.MemberType}");
                        Console.WriteLine("\n");
                    }
                }
                if (item.GetMethods().Count() > 0)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Methods:");
                    foreach (var item2 in item.GetMethods())
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine($"Method name: {item2.Name}");
                        Console.WriteLine("\n");
                        Console.WriteLine($"Return type : {item2.ReturnType.FullName}");
                        Console.WriteLine("\n");
                        if (item2.GetParameters().Count() > 0)
                        {
                            foreach (var item3 in item2.GetParameters())
                            {
                                Console.WriteLine("\n");
                                Console.WriteLine($"Parameters : {item3.ParameterType.FullName}");
                                Console.WriteLine("\n");
                            }
                        }
                    }
                    Console.WriteLine("==========================================================");
                    Console.WriteLine("\n");
                }
            }

            #endregion

            #region dynamic invokation of methods

            Console.WriteLine("\n");
            Console.WriteLine("=============================== reflection assembly object metadata ======================================");
            Console.WriteLine("\n");
            Console.WriteLine("create object from type");
            Console.WriteLine("\n");
            Console.WriteLine("Get all methods from type and invoke this with the previously created instance");
            Console.WriteLine("\n");
            Console.WriteLine("Commented out code is code which would be the dynamically added default value");
            Console.WriteLine("Problem is that no value can be given when invoked because the type is set at run time");
            Console.WriteLine("'Thats why a statically chosen value of null is chosen for a highest probability working code");
            Console.WriteLine("\n");
            Console.WriteLine("==========================================================");
            if (types.Count() > 0)
            {
                foreach (var objectitem in types)
                {
                    Console.WriteLine("Activator used for generating instance");
                    dynamic instance = Activator.CreateInstance(objectitem);

                    if (objectitem.GetMethods().Count() > 0)
                    {
                        foreach (var objectitem2 in objectitem.GetMethods())
                        {
                            var parameters = objectitem2.GetParameters();
                            if (parameters.Count() == 1)
                            {
                                var singleinputvaluetype = parameters.FirstOrDefault().ParameterType;
                                
                                ///
                                ///<summary>
                                /// below is the adjusted code to make code owkr with highest possible probabilty
                                ///</summary>
                                ///

                                //var singleinputvalue = default(singleinputvaluetype);
                                object objectinstance = objectitem2.Invoke(instance, new object[] { null });
                                //object objectinstance = objectitem2.Invoke(instance, new object[] { singleinputvalue });
                                Console.WriteLine("\n");
                                Console.WriteLine("one input method invoked");
                                Console.WriteLine("\n");
                            }
                        }
                    }
                }

            }

            #endregion
        }
    }
}
