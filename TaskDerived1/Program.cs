using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace TaskDerived1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Shop[] shops =
            {
                new ManufacturedGoods("Prada", 15585f, "shirt", "Prada"),
                new Supermarket("ATB", 33.9f, "tea", 0f),
                new ManufacturedGoods("Versace", 91000f, "dress", "Versace"),
                new ManufacturedGoods("Zara", 1299f, "hoodie", "Zara"),
                new Supermarket("Auchan", 31.26f, "chokolate", 60f)
            };
            foreach (var shop in shops)
            {
                Console.WriteLine(shop.ToString());
                Console.WriteLine(" ");
            }

            List<string> brands = File.ReadAllLines("luxury.txt").ToList();
            foreach (var shop in shops)
            {
                if (shop is Supermarket)
                {
                    var info = (Supermarket) shop;
                    Console.WriteLine(info.ContainsSugar());
                }
            }
            
            foreach (var shop in shops)
            {
                if (shop is ManufacturedGoods)
                {
                    var info = (ManufacturedGoods) shop;
                    Console.WriteLine(info.Luxury(brands));
                    Console.WriteLine(" ");
                }
            }

            Console.WriteLine("Sorted:");
            foreach (Shop shop in shops.OrderBy(shops => shops.NameOfShop))
            {
                Console.WriteLine(shop);
                Console.WriteLine(" ");
            }
        }
    }
}