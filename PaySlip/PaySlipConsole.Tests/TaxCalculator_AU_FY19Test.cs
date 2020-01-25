using PaySlipConsole.Model;
using System;
using Xunit;

namespace PaySlipConsole.Tests
{
    public class TaxCalculator_AU_FY19Test
    {
        [Fact]
        public void TestTaxWithTIE1()
        {
            TaxCalculator_AU_FY19 cal = new TaxCalculator_AU_FY19();
            Assert.Equal(0, cal.CalculateIncomeTax(0));
            Assert.Equal(0, cal.CalculateIncomeTax(20000));

        }
        [Fact]
        public void TestTaxWithTIE2()
        {
            TaxCalculator_AU_FY19 cal = new TaxCalculator_AU_FY19();
            Assert.Equal(0.1, cal.CalculateIncomeTax(20001));
            Assert.Equal(2000, cal.CalculateIncomeTax(40000));

        }
        [Fact]
        public void TestTaxWithTIE3()
        {
            TaxCalculator_AU_FY19 cal = new TaxCalculator_AU_FY19();
            Assert.Equal(2000.2, cal.CalculateIncomeTax(40001));
            Assert.Equal(10000, cal.CalculateIncomeTax(80000));
            Assert.Equal(6000, cal.CalculateIncomeTax(60000));

        }
        [Fact]
        public void TestTaxWithTIE4()
        {
            TaxCalculator_AU_FY19 cal = new TaxCalculator_AU_FY19();
            Assert.Equal(10000.3, cal.CalculateIncomeTax(80001));
            Assert.Equal(40000, cal.CalculateIncomeTax(180000));
            Assert.Equal(39999.7, cal.CalculateIncomeTax(179999));
        }

        [Fact]
        public void TestTaxWithTIE5()
        {
            TaxCalculator_AU_FY19 cal = new TaxCalculator_AU_FY19();
            Assert.Equal(40000.4, cal.CalculateIncomeTax(180001));
            Assert.Equal(858961458.80000007, cal.CalculateIncomeTax(2147483647));
            Assert.Equal(858961458.80000007, cal.CalculateIncomeTax(2147483648));
        }
    }
}
