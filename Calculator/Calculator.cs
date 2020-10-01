using System;

namespace Calculatorspace
{
 
        public class Calculator
        {
            public Calculator()
            {
                Accumulator = 0;
            }

            public double Add(double a, double b)
            {
                return Accumulator=a + b;
            }

            public double Add(double a)
            {
                return Accumulator += a;
            }

            public double Subtract(double a, double b)
            {
                return Accumulator=a - b;
            }

            public double Subtract(double a)
            {
                return Accumulator -= a;
            }
            public double Multiply(double a, double b)
            {
                return Accumulator=a * b;
            }

            public double Multiply(double a)
            {
                return Accumulator*=a;
            }
            public double Power(double x, double exp)
            {
                return Accumulator=Math.Pow(x, exp);
            }

            public double Power(double exp)
            {
                return Power(Accumulator, exp);
            }

            public double Divide(double dividend, double divisor)
            {
                if (divisor == 0)
                {
                    Accumulator=Double.NaN;
                    throw new DivideByZeroException();
                }
                
                else
                {
                    return Accumulator=dividend / divisor;
                }
            }

            public double Divide(double divisor)
            {
                return Divide(Accumulator, divisor);

            }
            public double Accumulator { get; private set; }

            public void Clear()
            {
                Accumulator = 0;
            }
        }

    

}
