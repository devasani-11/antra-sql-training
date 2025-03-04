using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_C__Learning
{
    class UnderstandingTypes
    {
        public static void DisplayInfo()
        {
            Console.WriteLine("Number Types Information Using Composite Formatting:");
            Console.WriteLine(new string('-', 75)); 

            Console.WriteLine(string.Format("{0,-10} | {1,-10} | {2,-30} | {3,-30}",
                "Type", "Bytes", "Min Value", "Max Value"));
            Console.WriteLine(new string('-', 75)); 

            PrintTypeInfo("sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue);
            PrintTypeInfo("byte", sizeof(byte), byte.MinValue, byte.MaxValue);
            PrintTypeInfo("short", sizeof(short), short.MinValue, short.MaxValue);
            PrintTypeInfo("ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
            PrintTypeInfo("int", sizeof(int), int.MinValue, int.MaxValue);
            PrintTypeInfo("uint", sizeof(uint), uint.MinValue, uint.MaxValue);
            PrintTypeInfo("long", sizeof(long), long.MinValue, long.MaxValue);
            PrintTypeInfo("ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
            PrintTypeInfo("float", sizeof(float), float.MinValue, float.MaxValue);
            PrintTypeInfo("double", sizeof(double), double.MinValue, double.MaxValue);
            PrintTypeInfo("decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);

            Console.WriteLine(new string('-', 75)); 
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void PrintTypeInfo<T>(string typeName, int byteSize, T min, T max)
        {
            Console.WriteLine(string.Format("{0,-10} | {1,-10} | {2,-30} | {3,-30}",
                typeName, byteSize, min, max));
        }
    }
}
