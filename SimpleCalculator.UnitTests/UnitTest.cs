using Moq;
using SimpleCalculator.Services;
using Xunit;

namespace SimpleCalculator.UnitTests
{
    public class UnitTest
    {
        Mock<IDiagnosticsService> mock = new Mock<IDiagnosticsService>();        
   
        [Fact]        
        public void InvalidOperationException()
        {
            var simple = new SimpleCalculatorService(mock.Object);
            var result = simple.Divide(5000, 0);
            Assert.True(result == -999, "ERROR");
        }

        [Fact]
        public void TestAddOperation()
        {
            var simple = new SimpleCalculatorService(mock.Object);
            var result = simple.Add(5000, 100);
            Assert.True(result == 5100, "ERROR");
        }

        [Fact]
        public void TestSubtractOperation()
        {
            var simple = new SimpleCalculatorService(mock.Object);
            var result = simple.Subtract(5000, 100);
            Assert.True(result == 4900, "ERROR");
        }

        [Fact]
        public void TestMultiplyOperation()
        {
            var simple = new SimpleCalculatorService(mock.Object);
            var result = simple.Multiply(5000, 10);
            Assert.True(result == 50000, "ERROR");
        }

        [Fact]
        public void TestDivideOperation()
        {
            var simple = new SimpleCalculatorService(mock.Object);
            var result = simple.Divide(5000, 10);
            Assert.True(result == 500, "ERROR");
        }
    }
}
