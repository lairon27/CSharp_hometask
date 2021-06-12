namespace TaskDerived1
{
    public class Shop
    {
        public string NameOfShop;
        public float CostOfGoods;

        public Shop()
        {
            NameOfShop = null;
            CostOfGoods = 0f;
        }
        
        public Shop(string _NameOfShop, float _CostOfGoods)
        {
            NameOfShop = _NameOfShop;
            CostOfGoods = _CostOfGoods;
        }
        
        public string _NameOfShop
        {
            get => NameOfShop;
            set => NameOfShop = value;
        }

        public float _CostOfGoods
        {
            get => CostOfGoods;
            set => CostOfGoods = value;
        }

        public override string ToString()
        {
            return "Name: " + NameOfShop + "\nPrice: " + CostOfGoods;
        }
    }
}