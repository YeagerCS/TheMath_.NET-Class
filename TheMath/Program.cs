using MathNet.Symbolics;

namespace TheMath
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TheMath.TheNthRoot(2, 512));
        }

        public void Test()
        {
            Math.Pow(2, 0.234832);
        }
    }
}