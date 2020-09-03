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
    }
}