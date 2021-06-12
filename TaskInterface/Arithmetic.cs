namespace TaskInterface
{
    public class Arithmetic : ISum
    { 
        public float FirstElement { get; set; }
        public float Difference { get; }

        public Arithmetic(float first, float dif)
        {
            FirstElement = first;
            Difference = dif;
        }
        
        public override string ToString()
        {
            return "a0 = " + FirstElement + " d = " + Difference;
        }
        
        public float Sum(int m)
        {
            float sum = 0;
            for (var i = 0; i < m; i++)
            {
                sum += FirstElement;
                FirstElement += Difference;
            }
            return sum;
        }
    }
}