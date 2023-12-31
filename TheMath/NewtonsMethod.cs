﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMath
{
    internal class NewtonsMethod
    {
        //ln(x) = y |e^()
        //x = e^y | -x
        //e^y - x = 0; f(y) = e^y - x;
        public static double LnF(double y, double x)
        {
            return TheMath.TheExp(y) - x;
        }

        //f'(y) = d/dy(e^y - x) = e^y;
        public static double LnDerivativeF(double y)
        {
            return TheMath.TheExp(y);
        }

        //sqrt(x) = y | ()^2
        //x = y^2
        //y^2 - x = 0; f(y) = y^2 - x
        public static double SqrtF(double y, double x)
        {
            return TheMath.ThePow(y, 2) - x;
        }

        //f'(y) = d/dy(y^2 - x) = 2y
        public static double SqrtDerivativeF(double y)
        {
            return 2 * y;
        }

        //nroot(x) = y | ()^n
        //x = y^n
        //y^n - x = 0; f(y) = y^n -x
        public static double NrootF(double y, double n, double x)
        {
            return TheMath.ThePow(y, n) - x;
        }

        //f'(y) = d/dy(y^n -x) = ny^n-1
        public static double NRootDerivativeF(double y, double n)
        {
            return n * TheMath.ThePow(y, n - 1);
        }
    }
}
