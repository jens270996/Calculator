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
        
        public void TestAdd()
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
    }
}