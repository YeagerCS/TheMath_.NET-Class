using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheMath
{
    public class TheMath
    {
        public const double PI = 3.1415926535897932384;
        public const double E = 2.7182818284590452353;

        public static double TheMin(double a, double b)
        {
            return a < b ? a : b;
        }

        public static double TheMax(double a, double b)
        {
            return a > b ? a : b;
        }

        public static double TheAbs(double n)
        {
            return n > 0 ? n : -n;
        }

        public static bool TheEquals(double a, double b)
        {
            return a == b;
        }

        private static double TheSimplePow(double n, uint x)
        {
            double result = 1;
            if (x > 0)
            {
                for(int i = 0; i < x; i++)
                {
                    result *= n;
                }
            }
            else 
            {
                return 1;
            }

            return result;
        }

        public static double TheFactorial(int n)
        {
            int result = 1;
            for(int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double TheExp(double n) 
        {
            double result = 1;
            double term = 1;
            const int k = 75;

            for(int i = 1; i <= k; i++)
            {
                term *= n / i;
                result += term;
            }

            return result;
        }

        public static double ThePow(double b, double x)
        {
            if (x == 0)
            {
                return 1;
            }
            else if (x > 0 && x % 1 == 0)
            {
                return TheSimplePow(b, (uint) x);
            }
            else
            {
                return TheExp(x * TheLn(b));
            }
        }


        public static double TheLn(double x)
        {
            double y = 1;
            for(int n = 0; n < 100; n++)
            {
                y = y - (NewtonsMethod.LnF(y, x) / NewtonsMethod.LnDerivativeF(y));
            }
            return y;
        }

        public static double TheSqrt(double x)
        {
            double y = x / 2;
            for(int n = 0; n < 30;n++)
            {
                y = y - (NewtonsMethod.SqrtF(y, x) / NewtonsMethod.SqrtDerivativeF(y));
            }
            return y;
        }

    }
}
