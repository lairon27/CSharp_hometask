namespace TaskDerived1
{
    public class Supermarket: Shop
    {
        public string Product;
        public float Sugar;
        
        public Supermarket()
        {
            Product = null;
            Sugar = 0f;
        }
        
        public Supermarket(string _NameOfShop, float _CostOfGoods, string _Product, float _Sugar) : base(_NameOfShop, _CostOfGoods)
        {
            Product = _Product;
            Sugar = _Sugar;
        }
        
        public string _Product
        {
            get => Product;
            set => Product = value;
        }

        public float _Sugar
        {
            get => Sugar;
            set => Sugar = value;
        }
        
        public override string ToString()
        {
            return "Name: " + NameOfShop + "\nProduct: " + Product + "\nPrice: " + CostOfGoods + "grn" + "\nSugar: " + Sugar + "%";
        }
        public string ContainsSugar()
        {
            if (Sugar > 0)
                return Product + " contains "+ Sugar + "% that not recommended for people with diabetes";
            
            return Product + "contains "+ Sugar + "% that can be consumed by people with diabetes";
        }
    }
}