using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 2017.7.11 Sunyelw do it.

namespace July11
{
    class AddSum
    {
        static int Sum(params int[] arr)
        {
            int sum = 0;
            foreach (int i in arr)
            {
                sum += i;
            }
            return sum;
        }

        public int[] Print(int n)
        {
            int[] arr = new int[n];
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("请输入第 {0} 个数组元素：", i);
                arr[i]=Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }

        static void Main(string[] args)
        {
            AddSum p = new AddSum();
            Console.WriteLine("请输入数组长度。");
            int x = Convert.ToInt32(Console.ReadLine());
            int[] arr =p.Print(x);
            int y = Sum(arr);
            Console.WriteLine("您输入的数组为：");
            foreach (int i in arr)
            {
                Console.WriteLine("{0}",i);
            }
            Console.WriteLine("数组的总和为：{0}", y);
            Console.ReadKey();
        }
    }
}
