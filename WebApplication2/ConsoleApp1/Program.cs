using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello 王大卫!");
            NoThing();
            var result = ShowMe();
            Console.WriteLine(result.code);
            Console.WriteLine(Calc());
            Console.WriteLine();
            Console.ReadLine();
        }

        public static void NoThing() => Console.WriteLine("大卫");

        private static (int code, string msg) ShowMe()
        {
            return (1, "11111111");
        }

        public static int Calc()
        {
           return calcJieCheng(5);

            int calcJieCheng(int x)
            {
                if (x > 1)
                    return calcJieCheng(x - 1) * x;
                else
                    return 1;
            }
        }
    }
}
