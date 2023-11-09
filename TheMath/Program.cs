namespace TheMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(TheMath.TheIntegral("log10(x)ln(x)x^3", 1, 3));
        }

        public void Test()
        {
            Math.Pow(2, 0.234832);
        }
    }
}