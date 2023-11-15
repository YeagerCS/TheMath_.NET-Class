namespace TheMathUnitTest
{
    [TestClass]
    public class TheMathFunctionsTest
    {
        [TestMethod]
        public void Number_7_TheIsPrime_Equals_True()
        {
            int n = 7;
            bool expected = true;

            bool actual = TheMath.TheMath.TheIsPrime(n);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Number_16_TheIsPrime_Equals_False()
        {
            int n = 16;
            bool expected = false;

            bool actual = TheMath.TheMath.TheIsPrime(n);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Point_4_6_Point_7_9_ThePointDistance_EqualsSqrt18()
        {
            (double x, double y) point1 = (4, 6);
            (double x, double y) point2 = (7, 9);
            double expected = Math.Sqrt(18);

            double actual = TheMath.TheMath.ThePointDistance(point1, point2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FourthRootOf88_TheNthRoot_Equals()
        {
            double root = 4;
            double x = 88;

            double expected = Math.Pow(x, (1 / root));


            double actual = TheMath.TheMath.TheNthRoot(root, x);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EToThePowerOf5_TheExp_Equals()
        {
            double power = 5;
            double expected = Math.Exp(power);

            double actual = TheMath.TheMath.TheExp(power);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LnOf2_TheLn_EqualsMathLog2()
        {
            double x = 2;
            double expected = Math.Log(x);

            double actual = TheMath.TheMath.TheLn(x);
            bool isApproximatelyEqual = TheMath.TheMath.TheApproximates(expected, actual);

            Assert.IsTrue(isApproximatelyEqual);
        }

        [TestMethod]
        public void SinPIDiv8_TheSin_EqualsMathSinPIDiv8()
        {
            double angle = double.Pi / 8;
            double expected = Math.Sin(angle);

            double actual = TheMath.TheMath.TheSin(angle);

            bool isApproximatelyEqual = TheMath.TheMath.TheApproximates(expected, actual);
            
            Assert.IsTrue(isApproximatelyEqual);
        }

        [TestMethod]
        public void ArcCosZeroPointFive_TheArcCos_EqualsMathAcosZeroPointFive()
        {
            double x = 0.5;
            double expected = Math.Acos(x);

            double actual = TheMath.TheMath.TheArcCos(x);

            bool isApproximatelyEqual = TheMath.TheMath.TheApproximates(expected, actual);

            Assert.IsTrue(isApproximatelyEqual);
        }

        [TestMethod]
        public void SinhPI_TheSinh_EqualsMathSinhPI()
        {
            double x = double.Pi;
            double expected = Math.Sinh(x);

            double actual = TheMath.TheMath.TheSinh(x);

            bool isApproximatelyEqual = TheMath.TheMath.TheApproximates(expected, actual);

            Assert.IsTrue(isApproximatelyEqual);
        }

        [TestMethod]
        public void ArcTanhZeroPointFive_TheArcTanh_EqualsMathAtanhZeroPointFive()
        {
            double x = 0.5;
            double expected = Math.Atanh(x);

            double actual = TheMath.TheMath.TheArcTanh(x);

            bool isApproximatelyEqual = TheMath.TheMath.TheApproximates(expected, actual);
            
            Assert.IsTrue(isApproximatelyEqual);
        }

    }
}