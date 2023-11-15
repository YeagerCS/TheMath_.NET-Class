using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace TheMath
{
    public class TheMath
    {
        //Constants

        public const double PI = 3.1415926535897932384;
        public const double E = 2.7182818284590452353;
        private const double RADIANS_TO_DEGREES = 180 / PI;
        private const double DEGREES_TO_RADIANS = PI / 180;

        //Algebra

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

        public static bool TheApproximates(double a, double b, double decimalApproximate = 6)
        {
            return TheDecimals(a, decimalApproximate) == TheDecimals(b, decimalApproximate);
        }

        public static double TheHyp(int a, int b)
        {
            return TheSqrt(ThePow(a, 2) + ThePow(b, 2));
        }

        public static bool TheIsPrime(int n)
        {
            if(n <= 1)
            {
                return false;
            }

            for(int i = 2; i <= n/2; i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>The total distance between the points p1 and p2</returns>
        public static double ThePointDistance((double x, double y) p1, (double x, double y) p2)
        {
            double deltaX = p2.x - p1.x;
            double deltaY = p2.y - p1.y;

            return TheSqrt(ThePow(deltaX, 2) + ThePow(deltaY, 2));
        }

        private static double TheSimplePow(double n, uint x)
        {
            double result = 1;
            if (x > 0)
            {
                for (int i = 0; i < x; i++)
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
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double TheReciprocal(double x)
        {
            return 1 / x;
        }

        public static int TheSign(double x)
        {
            if(x > 0)
            {
                return 1;
            } else if (x == 0)
            {
                return 0;
            }

            return -1;
        }

        public static int TheTruncate(double x)
        {
            return (int)x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>The greatest common divider of two integers</returns>
        public static int TheGCD(int a, int b)
        {
            a = (int)TheAbs(a);
            b = (int)TheAbs(b);

            while(b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>The least common multiple of two integers</returns>
        public static int TheLCM(int a, int b)
        {
            if(a == 0 || b == 0)
            {
                return 0;
            }

            a = (int)TheAbs(a);
            b = (int)TheAbs(b);

            return (a / TheGCD(a, b)) * b;
        }

        public static double ThePow(double b, double x)
        {
            if (x == 0)
            {
                return 1;
            }
            else if (x > 0 && x % 1 == 0)
            {
                return TheSimplePow(b, (uint)x);
            }
            else
            {
                return TheExp(x * TheLn(b));
            }
        }

        //by yn+1 = y - (f(y) / f'(y))
        public static double TheSqrt(double x)
        {
            double y = x / 2;
            for (int n = 0; n < 30; n++)
            {
                y = y - (NewtonsMethod.SqrtF(y, x) / NewtonsMethod.SqrtDerivativeF(y));
            }
            return y;
        }

        public static double TheNthRoot(double n, double x)
        {
            double y = x / n;
            for(int i = 0; i < 100; i++)
            {
                y = y - (NewtonsMethod.NrootF(y, n, x) / NewtonsMethod.NRootDerivativeF(y, n));
            }
            return y;
        }

        //Exponential

        //By Maclaurin series of e^x
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns>e^n, where n is the parameter</returns>
        public static double TheExp(double n)
        {
            double result = 1;
            double term = 1;
            const int k = 75;

            for (int i = 1; i <= k; i++)
            {
                term *= n / i;
                result += term;
            }

            return result;
        }


        //Logarithms

        //by yn+1 = y - (f(y) / f'(y))
        public static double TheLn(double x)
        {
            double y = 1;
            for (int n = 0; n < 100; n++)
            {
                y = y - (NewtonsMethod.LnF(y, x) / NewtonsMethod.LnDerivativeF(y));
            }
            return y;
        }

        public static double TheLogb(double b, double x)
        {
            return TheLn(x) / TheLn(b);
        }

        public static double TheLog10(double x)
        {
            return TheLn(x) / TheLn(10);
        }

        public static double TheLog2(double x)
        {
            return TheLn(x) / TheLn(2);
        }


        //Trigonometric

        //by Taylor series definition sin(x) = x - (x^3 / 3!) + (x^5 / 5!) - (x^7 / 7!) + ...
        /// <summary>
        /// The angle <param>x</param> in radians
        /// </summary>
        /// <returns>The sine of the angle x in radians</returns>
        public static double TheSin(double x)
        {
            x = ReduceAngle(x);
            double result = 0;
            double term = x;
            int n = 1;
            double epsilon = 1e-101;

            while (TheAbs(term) > epsilon)
            {
                result += term;
                term = (-term * x * x) / ((2 * n + 1) * (2 * n));
                n++;
            }

            double tolerance = 1e-15;

            if (TheAbs(result) < tolerance)
            {
                //The value is effectively zero
                result = 0;
            }
            return result;

        }
        /// <summary>
        /// The angle <param>x</param> in degrees
        /// </summary>
        /// <returns>The sine of the angle x in degrees</returns>
        public static double TheSinDeg(double x)
        {
            x = DEGREES_TO_RADIANS * x;
            return TheSin(x);
        }

        //D = R \ [nPI]
        /// <summary>
        /// The angle <param>x</param> in radians
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The cosecant (inverse sine) of x</returns>
        public static double TheCsc(double x)
        {
            x = ReduceAngle(x);
            if(x % PI == 0)
            {
                return double.NaN;
            }

            return 1 / TheSin(x);
        }

        /// <summary>
        /// The angle <param>x</param> in radians
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The secant (inverse cosine) of x</returns>
        public static double TheSec(double x)
        {
            x = ReduceAngle(x);
            if(x % (PI / 2) == 0)
            {
                return double.NaN;
            }
            return 1 / TheCos(x);
        }

        /// <summary>
        /// The angle <param>x</param> in radians
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The cotangent (inverse tangent) of x</returns>
        public static double TheCot(double x)
        {
            if(x % PI == 0)
            {
                return double.NaN;
            }

            return 1 / TheTan(x);
        }

        //by identity cos(x) = sin(π / 2 - x)
        /// <summary>
        /// The angle <param>x</param> in radians
        /// </summary>
        /// <returns>The cosine of the angle x in radians</returns>
        public static double TheCos(double x)
        {
            return TheSin((PI / 2) - x);
        }
        /// <summary>
        /// The angle <param>x</param> in degrees
        /// </summary>
        /// <returns>The cosine of the angle x in degrees</returns>
        public static double TheCosDeg(double x)
        {
            x = DEGREES_TO_RADIANS * x;
            return TheCos(x);
        }

        //by identity tan(x) = sin(x) / cos(x)
        /// <summary>
        /// The angle <param>x</param> in radians
        /// </summary>
        /// <returns>The tangent of the angle x in radians</returns>
        public static double TheTan(double x)
        {
            double value = TheSin(x) / TheCos(x);
            return value;
        }

        /// <summary>
        /// The angle <param>x</param> in degrees
        /// </summary>
        /// <returns>The tangent of the angle x in degrees</returns>
        public static double TheTanDeg(double x)
        {
            x = DEGREES_TO_RADIANS * x;
            return TheTan(x);
        }


        //Inverse Trigonometric


        //arcsin(x) = x + (x^3/3) + (1*3*x^5/5*7) + (1*3*5*x^7/5*7*9) + ... is to inaccurate, so
        //by identity arcsin(x) = arctan(x / sqrt(1 - x^2))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The angle in radians</returns>
        public static double TheArcSin(double x)
        {
            if (x < -1 || x > 1)
            {
                return double.NaN;
            }

            double result = TheArcTan(x / TheSqrt(1 - (x * x)));

            return result;
        }

        //by arctan(x) = x - (1/3)x^3 + (1/5)x^5 - (1/7)x^7 + (1/9)x^9 - ...
        //Only in the Domain [-1, 1]
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The angle in radians</returns>
        /// <returns></returns>
        public static double TheArcTan(double x)
        {
            if (x > 1)
            {
                return Math.PI / 2 - TheArcTan(1 / x); //by arctan(x) = π/2 - atan(1/x) for Domain R+ and x > 1
            }
            else if (x < -1)
            {
                return -Math.PI / 2 - TheArcTan(1 / x); //by arctan(x) = -π/2 - atan(1/x) for Domain R- and x < -1
            }

            if (x == 1)
            {
                return PI / 4;
            }

            double result = 0;
            double term = x;
            double factor = -x * x;
            double n = 1;

            while (true)
            {
                double nextTerm = term / n;

                if (TheAbs(nextTerm) < 1e-15)
                {
                    break;
                }

                result += nextTerm;
                term *= factor;
                n += 2;
            }

            return result;
        }


        //by identity arccos(x) = pi/2 - arcsin(x)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The angle in radians</returns>
        public static double TheArcCos(double x)
        {
            if (x < -1 || x > 1)
            {
                return double.NaN;
            }

            double result = (PI / 2) - TheArcSin(x);

            return result;
        }

        //by identity arccsc = arcsin(1/x)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The angle in radians</returns>
        public static double TheArcCsc(double x)
        {
            if(x > -1 && x < 1)
            {
                return TheArcSin(1 / x);
            }
            else
            {
                return double.NaN;
            }
        }


        //by identity arcsec(x) = arccos(1/x)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The angle in radians</returns>
        public static double TheArcSec(double x)
        {
            if (x > -1 && x < 1)
            {
                return TheArcCos(1 / x);
            }
            else
            {
                return double.NaN;
            }
        }


        //by identity arccot(x) = arctan(1/x)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The angle in radians</returns>
        public static double TheArcCot(double x)
        {
            if(x != 0)
            {
                return TheArcTan(1 / x);
            }
            else
            {
                return double.NaN;
            }
        }

        public static double TheConvertToDegrees(double rad)
        {
            return RADIANS_TO_DEGREES * rad;
        }

        public static double TheConvertToRadians(double deg)
        {
            return DEGREES_TO_RADIANS * deg;
        }

        public static double ReduceAngle(double x)
        {
            x = x % (2 * Math.PI); // Reduce to the range [0, 2*pi]
            if (x > Math.PI)
                x -= 2 * Math.PI; // Reduce to the range [-pi, pi]
            return x;
        }

    
        // Hyperbolic Trigonometric

        //by sinh(x) =  (e^x - e^-x) / 2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The hyperbolic sine of the angle x in radians</returns>
        public static double TheSinh(double x)
        {
            return (ThePow(E, x) - ThePow(E, -x)) / 2;
        }

        //by cosh(x) = (e^x + e^-x) / 2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The hyperbolic cosine of the angle x in radians</returns>
        public static double TheCosh(double x)
        {
            return (ThePow(E, x) + ThePow(E, -x)) / 2;
        }

        //by tanh(x) = sinh(x) / cosh(x)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The hyperbolic tangent of the angle x in radians</returns>
        public static double TheTanh(double x)
        {
            return TheSinh(x) / TheCosh(x);
        }


        // Inverse Hyperbolic Trigonometric

        //by arcsinh(x) = ln(x + sqrt(x^2 + 1)) for R
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The angle in radians</returns>
        /// <param name="x"></param>
        public static double TheArcSinh(double x)
        {
            return TheLn(x + TheSqrt(ThePow(x, 2) + 1));
        }

        //by arccosh(x) = ln(x + sqrt(x^2 - 1)) for x >= 1
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The angle in radians</returns>
        public static double TheArcCosh(double x)
        {
            if(x >= 1)
            {
                return TheLn(x + TheSqrt(ThePow(x, 2) - 1));
            }
            else
            {
                return double.NaN;
            }
        }

        //by arctanh(x) = 1/2 * ln((1 + x) / (1 - x)) for x > -1, x < 1
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns>The angle in radians</returns>
        public static double TheArcTanh(double x)
        {
            if(x > -1 && x < 1)
            {
                return .5 * TheLn((1 + x) / (1 - x));
            }
            else
            {
                return double.NaN;
            }
        }


        // Calculus

        /// <summary>
        /// Calculates the definite integral of a function with respect to x.
        /// Uses org.mariuszgromada.math.mxparser to parse a function string
        /// </summary>
        /// <param name="functionString">The mathemtical expression representing a function f(x)</param>
        /// <param name="a">Lower limit of integration</param>
        /// <param name="b">Upper limit of integration</param>
        /// <returns>The definite integral from a to b of inputted functionString</returns>
        public static double TheIntegral(string functionString, double a, double b)
        {
            Expression expression = new Expression(functionString, new Argument("x"));
            License.iConfirmNonCommercialUse("TheMath");
            Function func = new Function("f(x) = " + functionString);

            const double n = 1e+3;
            double dx = (b - a) / n;
            double sum = .5 * (func.calculate(a) + func.calculate(b));

            for (int i = 1; i < n; i++)
            {
                double x = a + i * dx;
                sum += func.calculate(x);
            }

            return dx * sum;
        }

        /// <summary>
        /// Calculates the derivative of a function with respect to x at given point.
        /// Uses org.mariuszgromada.math.mxparser to parse a function string
        /// </summary>
        /// <param name="functionString">The mathemtical expression representing a function f(x)</param>
        /// <param name="point">The point at which the derivative is calculated</param>
        /// <returns>The derivative of a function f(x) at given point</returns>
        public static double TheDerivative(string functionString, double point)
        {
            Expression expression = new Expression(new Argument("x"));

            License.iConfirmNonCommercialUse("TheMath");
            Function func = new Function("f(x) = " + functionString);

            const double h = 1e-8;
            double derivative = (func.calculate(point + h) - func.calculate(point - h)) / (2 * h);

            return derivative;
        }


        //Rounding / Floor / Ceil

        public static int TheRound(double x)
        {
            int result = 0;
            string[] splittedString = x.ToString().Split(".");
            if(splittedString.Length > 1)
            {
                string decimalString = splittedString[1];
                double decimals = Convert.ToInt64(decimalString) / ThePow(10, decimalString.Length);

                if(decimals >= .5)
                {
                    //Round up
                    result = (int)x + 1;
                }
                else
                {
                    result = (int)x;
                }
            }
            else
            {
                return (int)x;
            }

            return result;
        }

        public static int TheFloor(double x)
        {
            return (int)x;
        }

        public static int TheCeil(double x)
        {
            return (int)x + 1;
        }

        public static double TheDecimals(double n, double l)
        {
            if(l < 0)
            {
                throw new ArgumentException("Decimal places can't be negative");
            }

            double multiplier = ThePow(10, l);
            return TheRound(n * multiplier) / multiplier;
        }


        // Statistics

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The mean (average) of a list of numbers</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double TheMean(IEnumerable<double> numbers)
        {
            if(numbers == null || !numbers.Any())
            {
                throw new ArgumentException("The list of numbers is null or empty");
            }

            return numbers.Sum() / numbers.Count();
        }

        /// <summary>
        /// Calculates the median, which is the value where 50% of the values are above and 50% below it.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The median of a list of numbers</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double TheMedian(IEnumerable<double> numbers)
        {
            if (numbers == null || !numbers.Any())
            {
                throw new ArgumentException("The list of numbers is null or empty");
            }

            var sortedNumbers = numbers.OrderBy(n => n).ToList();
            int count = sortedNumbers.Count;

            if (count % 2 == 0)
            {
                int middleIndex1 = count / 2 - 1;
                int middleIndex2 = count / 2;
                return (sortedNumbers[middleIndex1] + sortedNumbers[middleIndex2]) / 2;
            }
            else
            {
                int middleIndex = count / 2;
                return sortedNumbers[middleIndex];
            }
        }

        /// <summary>
        /// Calculates the mode, which are the numbers that appear most in a list
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The mode of a list of numbers</returns>
        /// <exception cref="ArgumentException"></exception>
        public static List<double> TheMode(IEnumerable<double> numbers)
        {
            if (numbers == null || !numbers.Any())
            {
                throw new ArgumentException("The list of numbers is empty or null.");
            }

            Dictionary<double, int> frequencyDict = new Dictionary<double, int>();
            foreach (var number in numbers)
            {
                if (frequencyDict.ContainsKey(number))
                    frequencyDict[number]++;
                else
                    frequencyDict[number] = 1;
            }

            int maxFrequency = frequencyDict.Values.Max();
            return frequencyDict.Where(kv => kv.Value == maxFrequency).Select(kv => kv.Key).ToList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The variance of a list of numbers</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double TheVariance(IEnumerable<double> numbers)
        {
            if (numbers == null || !numbers.Any())
            {
                throw new ArgumentException("The list of numbers is empty or null.");
            }

            double mean = TheMean(numbers);
            double sumOfSquares = numbers.Sum(n => Math.Pow(n - mean, 2));

            return sumOfSquares / numbers.Count();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>The standard deviation of a list of numbers</returns>
        public static double TheStandardDeviation(IEnumerable<double> numbers)
        {
            return TheSqrt(TheVariance(numbers));
        }
    }
}
