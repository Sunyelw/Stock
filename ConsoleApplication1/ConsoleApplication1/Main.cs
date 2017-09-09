using System;
namespace HelloWorldApplication
{
    public class HelloWorld
    {
        private static String[] Nums;
        private int len;
        public static void Permutation(string[] nums, int m, int n)
        {
           string t;
            if (m < n - 1)
            {
                Permutation(nums, m + 1, n);
                for (int i = m + 1; i < n; i++)
                {
                    //可抽取Swap方法
                    t = nums[m];
                    nums[m] = nums[i]; 
                    nums[i] = t;

                    Permutation(nums, m + 1, n);

                    //可抽取Swap方法
                    t = nums[m];
                    nums[m] = nums[i];
                    nums[i] = t;
                }

            }
            else
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    Console.WriteLine(nums[j]);
                }
                Console.WriteLine("m:{0},n:{1}", m, n);
                Console.WriteLine();
            }
        }
        class Xyz
        {
            static void Main(string[] args)
            {
                HelloWorld a = new HelloWorld();
                Xyz x = new Xyz();  
                a.len = 1;
                Nums = new string[] { "a", "b", "c" };
                Permutation(Nums, 0, Nums.Length);
                Console.WriteLine("Size of int: {0}", a.len);
                Console.ReadKey();
            }
        }
    }
}