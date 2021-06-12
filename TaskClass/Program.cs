using System;

class Baggage
{
    public string Surname { get; set; }
    public int NumberOfThings { get; set; }
    public float BaggageWeight{ get; set; }

    public Baggage()
    {
        Surname = null;
        NumberOfThings = 0;
        BaggageWeight = 0f;
    }
    
    public Baggage(int num, float weight, string surname)
    {
        NumberOfThings = num;
        BaggageWeight = weight;
        Surname = surname;
    }
    
    public override string ToString()
    {
        return Surname + " have " + NumberOfThings + " things and " + BaggageWeight + "kg";
    }

    public int moreThanTwoThings()
    {
        int amountOfPassengers = 0;
        if (NumberOfThings > 2)
            amountOfPassengers += 1;
        
        return amountOfPassengers;
    }

    public void totalBaggageWeight(float averageWeight, int n)
    {
        if(BaggageWeight > averageWeight/n)
            Console.WriteLine($"The weight of the {Surname} baggage exceeds the {averageWeight/n}");
    }
}

namespace TaskClass
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Baggage baggage = new Baggage();
            Console.Write("Enter amount of passengers: ");
            int n = int.Parse(Console.ReadLine());
            Baggage[] passengers = new Baggage [n];
            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = new Baggage();
                Console.Write("Surname: ");
                passengers[i].Surname = Console.ReadLine();
                Console.Write("Number of things: ");
                passengers[i].NumberOfThings = int.Parse(Console.ReadLine());
                Console.Write("Baggage weight: ");
                passengers[i].BaggageWeight = float.Parse(Console.ReadLine());
                Console.WriteLine(passengers[i].ToString());
            }
            
            int amountOfPassengers = 0;
            for (int i = 0; i < passengers.Length; i++)
                amountOfPassengers += passengers[i].moreThanTwoThings();
            
            Console.WriteLine($"More than 2 things have {amountOfPassengers} passengers");
            
            float averageWeight = 0f;
            for (int i = 0; i < passengers.Length; i++)
                averageWeight += passengers[i].BaggageWeight;
            
            for (int i = 0; i < passengers.Length; i++)
                passengers[i].totalBaggageWeight(averageWeight, n);
        }
    }
}