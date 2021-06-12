using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TaskInterface
{
    internal static class Program
    {
        private delegate void Message();
        private static bool MainMenu()
        {
            Console.ReadKey();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Arithmetic progression");
            Console.WriteLine("2) Geometric progression");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");
            float sum;
 
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Arithmetic progressions:");
                    try
                    {
                        var fileLines = File.ReadAllLines("text.txt");
                        var size = int.Parse(fileLines[0]);
                        var arithmeticArray = new Arithmetic[size];
                        var count = 0;
                        foreach (var line in fileLines.Skip(1))
                        {
                            var arr = line.Split(' ');
                            arithmeticArray[count] = new Arithmetic(float.Parse(arr[0]), float.Parse(arr[1]));
                            count++;
                        }
                        
                        foreach(var item in arithmeticArray)
                            Console.WriteLine(item);
                    
                        var arithmeticSumList = new List<float>();
                    
                        Console.WriteLine();
                        Console.WriteLine("Sum:");
                        foreach (var t in arithmeticArray)
                        {
                            sum = t.Sum(size-1);
                            Console.WriteLine(sum);
                            arithmeticSumList.Add(sum);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Sorted:");
                        foreach (var sum1 in arithmeticSumList.OrderByDescending(shops => shops))
                        {
                            Console.WriteLine(sum1);
                        }
                        Console.WriteLine();
                        Console.WriteLine("press Enter");
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("The file could not be read");
                    }
                    return true;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Geometric progressions:");
                    try
                    {
                        var fileLines1 = File.ReadAllLines("text1.txt");
                        var size1 = int.Parse(fileLines1[0]);
                        var geometricArray = new Geometric[size1];
                        var count1 = 0;
                        foreach (var line in fileLines1.Skip(1))
                        {
                            var arr = line.Split(' ');
                            geometricArray[count1] = new Geometric(float.Parse(arr[0]), float.Parse(arr[1]));
                            count1++;
                        }
                        
                        foreach(var item in geometricArray)
                            Console.WriteLine(item);
                        
                        var geometricSumList = new List<float>();
                        
                        Console.WriteLine();
                        Console.WriteLine("Sum:");
                        foreach (var t in geometricArray)
                        {
                            sum = t.Sum(size1-1);
                            Console.WriteLine(sum);
                            geometricSumList.Add(sum);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Sorted:");
                        foreach (var sum1 in geometricSumList.OrderByDescending(shops => shops))
                        {
                            Console.WriteLine(sum1);
                        }
                        Console.WriteLine();
                        Console.WriteLine("press Enter");
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("The file could not be read");
                    }
                    return true;
                case "3":
                    Console.Clear();
                    Console.WriteLine("BYE");
                    return false;
                default:
                    return true;
            }
        }
        
        public static void Main(string[] args)
        {
            Messages();
            var showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static void Messages()
        {
            Message mes; 
            if (DateTime.Now.Hour < 12)
            {
                mes = GoodMorning; 
            }
            else
            {
                mes = GoodEvening;
            }
            mes(); 
        }
        private static void GoodMorning()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Good Morning --> press Enter");
            Console.ResetColor();
        }
        private static void GoodEvening()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Good Evening --> press Enter");
            Console.ResetColor();
        }
    }
}