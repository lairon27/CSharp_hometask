using System;

namespace Task1
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Console.Write("Enter n: ");
                int q = int.Parse(Console.ReadLine());
                int[] array = new int[q];
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"Element {i} = ");
                    array[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Perfect numbers: ");
                for (int i = 0; i < array.Length; i++)
                {
                    if (perfectNum(array[i]))
                        Console.WriteLine($"{array[i]}");
                }
        }
        static bool perfectNum(int num) 
        { 
            int sum = 0; 
            for (int i = 1; i <= num / 2; i++)  
            {
                if (num % i == 0)  
                { 
                    sum += i; 
                } 
            } 
            return sum == num; 
        }
    }
}