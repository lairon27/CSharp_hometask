using System.Collections.Generic;
namespace TaskDerived1
{
    public class ManufacturedGoods: Shop
    {
        public string Clothes;
        public string Brand;
        
        public ManufacturedGoods()
        {
            Clothes = null;
            Brand = null;
        }
        
        public ManufacturedGoods(string _NameOfShop, float _CostOfGoods, string _Clothes, string _Brand) : base(_NameOfShop, _CostOfGoods)
        {
            Clothes = _Clothes;
            Brand = _Brand;
        }
        
        public string _Clothes
        {
            get => Clothes;
            set => Clothes = value;
        }

        public string _Brand
        {
            get => Brand;
            set => Brand = value;
        }

        public override string ToString()
        {
            return "Name: " + NameOfShop + "\nGoods: " + Clothes + "\nPrice: " + CostOfGoods + "grn" + "\nBrand: " + Brand;
        }
        
        public string Luxury(List<string> brands)
        {
            foreach (var brand in brands)
            {
                if (Brand == brand)
                {
                    return $"Luxury:\n{Brand} -- {Clothes}\n{CostOfGoods}grn";
                }
            }

            return $"Mass market:\n{Brand} -- {Clothes}\n{CostOfGoods}grn";
        }
    }
}