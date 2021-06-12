using System;
using System.IO;
using System.Linq;

namespace TaskDelegate
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var fileLines = File.ReadAllLines("1.txt");
                var size = int.Parse(fileLines[0]);
                var passengers = new Baggage[size];
                
                var count = 0;
                foreach (var line in fileLines.Skip(1))
                {
                    var arr = line.Split(' ');
                    int buf;
                    float buf1;
                    try
                    {
                        passengers[count] = new Baggage(arr[0], int.Parse(arr[1]), float.Parse(arr[2]));
                        count++;
                    }
                    catch
                    {
                        if (!int.TryParse(arr[1],out buf))
                        {
                            Console.WriteLine( "Wrong value" );
                            break;
                        }

                        if (!float.TryParse(arr[2], out buf1))
                        {
                            Console.WriteLine( "Wrong value" );
                            break;
                        }
                    }
                }
                
                foreach (var item in passengers)
                    Console.WriteLine(item);
                
                Console.WriteLine();
                var amountOfPassengers = 0;
                var colorDelegate = new Baggage.BaggageStateHandler(Color_Message);
                var showDelegate = new Baggage.BaggageStateHandler(Show_Message);
                foreach (var t in passengers)
                {
                    t.RegisterHandler(colorDelegate);
                    t.permissibleWeight();
                }
                
                Console.WriteLine();
                
                foreach (var t in passengers)
                {
                    t.UnregisterHandler(colorDelegate);
                    t.RegisterHandler(showDelegate);
                    amountOfPassengers += t.moreThanTwoThings();
                }
               
                Console.WriteLine();
                
                Console.WriteLine($"Total more than 2 things have {amountOfPassengers} passengers");
            }
            catch
            {
                Console.WriteLine("The file could not be read");
            }
        }
        
        private static void Color_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        
        private static void Show_Message(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}