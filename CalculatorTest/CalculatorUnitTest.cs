using System;
using NUnit.Framework;
using Calculatorspace;

namespace CalculatorTest
{
   
    public class Tests

    {
        Calculator uut;

        [SetUp]
        public void Setup()
        {
            uut = new Calculator();
        }


        //Tests of Add
        [Test]
        public void Add_5plus9_is14()
        {
            
            Assert.That(uut.Add(5, 9),Is.EqualTo(14));
        }
        [Test]
        public void Add_0Point001plus0_is0Point001()
        {

            Assert.That(uut.Add(0.001, 0), Is.EqualTo(0.001));
        }
        [Test]
        public void Add_0PointNegative001plus0_isNegative0Point001()
        {

            Assert.That(uut.Add(-0.001, 0), Is.EqualTo(-0.001));
        }



        //Accumulator add test
        [Test]
        public void AccumulatorAdd_7Point490PlusAccumulator_Is7Point490()
        {

            Assert.That(uut.Add(7.490), Is.EqualTo(7.490));
        }

        //Tests of Subtract
        [Test]
        public void Subtract_0Minus6P51_IsNegative6P51()
        {
            Assert.That(uut.Subtract(0,6.51), Is.EqualTo(-6.51));
        }
        
        [Test]
        public void Subtract_7P48Minus6P51_Is0P97()
        {
            Assert.That(uut.Subtract(7.48, 6.51), Is.EqualTo(0.97).Within(0.000001));
        }

        [Test]
        public void Subtract_7P48MinusNegative6P51_Is13P99()
        {
            Assert.That(uut.Subtract(7.48, -6.51), Is.EqualTo(13.99).Within(0.000001));
        }

        //Test of accumulator subtract:
        [Test]
        public void AcuSubtract_7P48_IsNegative7p48()
        {
            Assert.That(uut.Subtract(7.48), Is.EqualTo(-7.48).Within(0.000001));
        }


        //Tests of multiply

        //product of 0 is 0
        [TestCase(99999.999,0,0)]
        //negative times positive is negative
        [TestCase(7.48, -6.51, -48.6948)]
        //negative times negative is positive
        [TestCase(-7.48, -6.51, 48.6948)]
        public void Multiply_aTimesb_Isc(double a,double b,double c)
        {
            Assert.That(uut.Multiply(a, b), Is.EqualTo(c).Within(0.000001));
        }


        //Test of accumulator multiply
        [Test]
        public void AccumulatorMultiply_AcuSetTo7p49Times7p49_Is56p1001()
        {
            //Set acu to 7.49
            uut.Add(7.49);
            Assert.That(uut.Multiply(7.49), Is.EqualTo(56.1001).Within(0.000001));
        }


        //Tests of Power
        [Test]
        public void Power_ExponentOfZero_IsOne()
        {
            Assert.That(uut.Power(5,0),Is.EqualTo(1));
        }

        [Test]
        public void Power_PowerOfOne_IsOne()
        {
            Assert.That(uut.Power(1,9),Is.EqualTo(1));
        }

        [Test]
        public void Power_8ToThePower2_Is64()
        {
            Assert.That(uut.Power(8, 2), Is.EqualTo(64));
        }




        //Tests of Accumulator
        [Test]
        public void Accumulator_InitialValue_IsZero()
        {
            
            Assert.That(uut.Accumulator, Is.EqualTo(0));
        }

        
        [Test]
        public void Accumulator_CalculationsWithPositiveIntegers_IsLatestResult()
        {
            uut.Add(5, 6);
            uut.Multiply(3, 1);
            Assert.That(uut.Accumulator, Is.EqualTo(3));
        }

        [Test]
        public void Divide_DivisionByZero_AccumulatorIsNaN()
        {
            try
            {
                uut.Divide(5.5, 0);
            }
            catch (Exception e)
            {
                
            }
            Assert.That(uut.Accumulator,Is.EqualTo(Double.NaN));
        }



        //Test of divide
       
        [Test]

        public void Divide_DividentIsZero_EqualsZero()
        {
            uut.Divide(0, 0.00094);
            Assert.That(uut.Accumulator,Is.EqualTo(0));
        }
        [Test]
        public void Divide_DividentAndDivisorIsNegative_PositiveResult()
        {
            Assert.That(uut.Divide(-97.38,-84.21),Is.EqualTo(1.1563947275).Within(0.0000001));
        }

        [Test]
        public void Divide_DividentIsNegative_NegativeResult()
        {
            Assert.That(uut.Divide(-97.38, 84.21), Is.EqualTo(-1.1563947275).Within(0.0000001));
        }

        //test of exception

        [Test]
        public void Divide_DivisionByZero_ThrowsException()
        {
            Assert.That(() => uut.Divide(5.5, 0), Throws.TypeOf<DivideByZeroException>());

        }

    }
}