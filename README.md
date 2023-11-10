# Functions

## Constants
- E = 2.7182818284590452353
- PI = 3.1415926535897932384

## Algebraic / General
- Min(a, b) => returns the smaller of two values.
- Max(a, b) => returns the larger of two values.
- Abs(x) => returns the absolute value of a number.
- Equals(a, b) => returns a boolean decided by the equality of two values.
- Hyp(a, b) => returns the hypotenuse calculated by cathethers a and b.
- Factorial(x) => returns the factorial of a value.
- Reciprocal(x) => returns the reciprocal (^-1) of a value.
- Sign(x) => returns 1 when x is positive and -1 when x is negative.
- Truncate(x) => returns x without the decimals.
- Pow(a, b) => returns a to the power of b.
- Sqrt(x) => returns the square root of a number.
- Nroot(n, x) => returns the nth root of a number.

## Exponential / Logarithmic
- Exp(x) => return e to the power of x.
- Ln(x) => returns the natural log of x.
- Logb(b, x) => returns the log base b of x.
- Log10(x) => returns the log base 10 of x.
- Log2(x) => returns the log base 2 of x.

## Trigonometric
- Sin(x) => returns the sine of an angle, x in radians.
- Cos(x) => returns the cosine of an angle, x in radians.
- Tan(x) => returns the tangent of an angle, x in radians.
- SinDeg(x) => returns the sine of an angle, x in degrees.
- CosDeg(x) => returns the cosine of an angle, x in degrees.
- TanDeg(x) => returns the tangent of an angle, x in degrees.
- Csc(x) => returns the cosecant of an angle, x in radians.
- Sec(x) => returns the secant of an angle, x in radians.
- Cot(x) => returns the cotangent of an angle, x in radians.

## Inverse Trigonometric
- Arcsin(x) => returns the angle y when sin(y) = x in radians (inverse sine).
- Arccos(x) =>  returns the angle y when cos(y) = x in radians (inverse cosine).
- Arctan(x) =>  returns the angle y when tan(y) = x in radians (inverse tangent).

## Hyperbolic Trigonometric
- Sinh(x) => returns the hyperbolic sine of an angle, x in radians.
- Cosh(x) => returns the hyperbolic cosine of an angle, x in radians.
- Tanh(x) => returns the hyperbolic tangent of an angle, x in radians.

## Inverse Hyperbolic Trigonometric
- Arcsinh(x) => returns the angle y when sinh(y) = x in radians (inverse hyperbolic sine).
- Arccosh(x) =>  returns the angle y when cosh(y) = x in radians (inverse hyperbolic cosine).
- Arctanh(x) =>  returns the angle y when tanh(y) = x in radians (inverse hyperbolic tangent).

## Rounding
- Round(x) => rounds a number up if it's decimals are above 0.5 and down if they're below.
- Floor(x) => round down a number.
- Ceil(x) => rounds up a number.

## Calculus
- Integral(func, a, b) => returns the definite integral of the function string 'func' going from a to b.  
  The method takes a function string like "ln(x)x^2" and this string is converted to an actual function by utilizing the ```org.mariuszgromada.math.mxparser``` NuGet package.

# Details

## Newtons Method
Some functions like ln(x), sqrt(x) and nroot(x) are calculated using Newtons method which states the following:
<p align="center">
  <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnEnTP7CqA8POv-vPOINI3K2vkLFErO-dJSP3l_UxCHu6ZXRDJgArCkEZR-LVI8kl7xIY&usqp=CAU" alt="newtons method" width="500"/>
</p>
This method allows for a efficient and accurate calculation of these functions.

## Trig functions
The trig functions are implemented by their taylor series definition.
<p align="center">
  <img src="https://pbs.twimg.com/media/DJfUzO4VoAAKNgj.jpg" alt="taylor series" width="500"/>
</p>

## e^x
e^x is programmed with the Maclaurin series...

## Inverse Trig functions
The simplest and most accurate algorithm to code is the arctan(x), which is why the other inverse functions are defined using an arctan identity. These are the deriviations of this type of identities:
<p align="center">
  <img src="TheMath\images\arcsin.png" alt="arcsin definiotn" width="500"/> <img src="https://www.rapidtables.com/math/trigonometry/arcsin/arcsin-graph.png" alt="arcsin graph" width="200"/>
</p>  
The arccos is just arccos(x) = π/2 - arcsin(x)

## Trapezoidal Rule
The definite integral is calculated using the trapezoidal rule:
<p align="center">
  <img src="https://www.bragitoff.com/wp-content/uploads/2015/08/TrapezoidRule1.png" alt="trapezoidal rule" width="500"/>
</p>
