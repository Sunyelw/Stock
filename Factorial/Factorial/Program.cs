using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        public long Factorial(int num)
        {
            long rel;
            if (num == 1)
            {
                return num;
            }
            else
            {
                rel = Factorial(num - 1) * num;
                return rel;
            }
        }
        //static void Main(String[] args)
        //{
        //    Program x = new Program();
        //    Console.WriteLine("请输入一个整数：");
        //    int a = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("数 {0} 的阶乘是:{1}", a, x.Factorial(a));
        //    Console.ReadLine();
        //}
    }
}
