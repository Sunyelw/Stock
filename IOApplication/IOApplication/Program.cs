using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int num,a;
            a = 1;
            //num = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("输入的是：{0}", num);
            //Console.ReadKey();
           for (num = 0; num < 100; num++)
              // for (; ; )
                {
                    
                    Console.WriteLine("endless loop:{0}!!\n",a);
                    a++;

                }
            Console.ReadKey();
        }
    }
}
