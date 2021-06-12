namespace TaskInterface
{
    public class Geometric : ISum
    {
        public float FirstElement { get; set; }
        public float Denominator { get; }
        
        public Geometric(float first, float denominator)
        {
            FirstElement = first;
            Denominator = denominator;
        }
        
        public override string ToString()
        {
            return "a0 = " + FirstElement + " q = " + Denominator;
        }
        
        public float Sum(int m)
        {
            float sum = 0;
            for (var i = 0; i < m; i++)
            {
                sum += FirstElement ; 
                FirstElement *= Denominator;
            } 
            return sum; 
        }
    }
}