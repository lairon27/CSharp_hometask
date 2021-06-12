using System;

namespace TaskString
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter string: ");
            var s = Console.ReadLine();
            var result = "";
            
            if (s.LastIndexOf(".") != s.Length - 1)
                Console.WriteLine("No dot in the end");
            
            else
            {
                for (var i = 0; i < s.Length; i++)
                    if(s[i] == ' ' || s[i] == '.')
                        s = s.Remove(i - 1, 1);
                
                var s1 = string.Join(" ", s);
                Console.WriteLine(s1);
            }
        }
    }
}