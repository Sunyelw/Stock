using System;

namespace Factorial
{
    class Test
    {
        public void swap(int x, int y)
      {
         int temp;
         
         temp = x; 
         x = y;    
         y = temp; 
      }
        
      
      static void Main(String[] args)
      {
         Test n = new Test();
         /* 局部变量定义 */

         int a = 100;
         int b = 200;

         Console.WriteLine("在交换之前，a 的值： {0}", a);
         Console.WriteLine("在交换之前，b 的值： {0}", b);
         
         /* 调用函数来交换值 */
         n.swap(a, b);
         
         Console.WriteLine("在交换之后，a 的值： {0}", a);
         Console.WriteLine("在交换之后，b 的值： {0}", b);
         
         Console.WriteLine();
      }
   } 
}
