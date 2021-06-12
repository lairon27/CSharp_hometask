namespace TaskDelegate
{
    public class Baggage
    {
        public delegate void BaggageStateHandler(string message);

        private BaggageStateHandler _del;
 
        public void RegisterHandler(BaggageStateHandler del)
        {
            _del += del; 
        }
        public void UnregisterHandler(BaggageStateHandler del)
        {
            _del -= del; 
        }
        
        public string Surname { get; set; }
        public int NumberOfThings { get; set; }
        public float BaggageWeight{ get; set; }
        
        public Baggage( string surname, int num, float weight)
        {
            Surname = surname;
            NumberOfThings = num;
            BaggageWeight = weight;
        }
    
        public override string ToString()
        {
            return Surname + " have " + NumberOfThings + " things by weight " + BaggageWeight + "kg";
        }

        public void permissibleWeight()
        {
            var permissible = 10f;
            _del(BaggageWeight <= permissible
                ? $"{Surname} has a permissible weight {BaggageWeight}kg of luggage"
                : $"Luggage {Surname} exceeds the permissible weight {BaggageWeight}kg");
        }
        
        public int moreThanTwoThings()
        {
            var amountOfPassengers = 0;
            if (NumberOfThings > 2)
            {
                amountOfPassengers += 1;
                _del($"{Surname} has more than 2 things - {NumberOfThings}");
            }
            return amountOfPassengers;
        }
    }
}