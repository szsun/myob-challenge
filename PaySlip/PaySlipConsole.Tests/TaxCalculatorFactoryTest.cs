using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PaySlipConsole.Model;
namespace PaySlipConsole.Tests
{
    public class TaxCalculatorFactoryTest
    {
        [Fact]
        public void SingletonTest()
        {
            TaxCalculatorFactory fac1 = TaxCalculatorFactory.Instance;
            TaxCalculatorFactory fac2 = TaxCalculatorFactory.Instance;

            Assert.True(fac1 == fac2);
        }

        [Fact]
        public void CreateAUFY19Test()
        {
            TaxCalculatorFactory fac1 = TaxCalculatorFactory.Instance;
            ITaxCalculator cal = fac1.GetTaxCalculator(PaySlipLocation.AU, PaySlipFY.FY19);
            Assert.True(cal is TaxCalculator_AU_FY19);

            cal = fac1.GetTaxCalculator(PaySlipLocation.US, PaySlipFY.FY19);
            Assert.True(cal is null);

            cal = fac1.GetTaxCalculator(PaySlipLocation.AU, PaySlipFY.FY20);
            Assert.True(cal is null);
        }
    }
}
