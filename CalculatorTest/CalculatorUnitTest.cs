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

        [Test]
        public void Add_5plus9_is14()
        {
            
            Assert.That(uut.Add(5, 9),Is.EqualTo(14));
        }

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
        public void Accumulator_CalculationsWithPositiveIntegers_IsLatestResult()
        {
            uut.Add(5, 6);
            uut.Multiply(3, 1);
            Assert.That(uut.Accumulator, Is.EqualTo(3));
        }

        [Test]

        public void Divide_DivisionByZero_ThrowsException()
        {
            Assert.That(()=>uut.Divide(5.5,0),Throws.TypeOf<DivideByZeroException>());

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
    }
}