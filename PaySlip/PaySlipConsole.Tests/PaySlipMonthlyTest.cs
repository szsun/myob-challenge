using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PaySlipConsole.Model;
namespace PaySlipConsole.Tests
{
    
    public class PaySlipMonthlyTest
    {
        
        [Fact]
        public void NormalCreationTest (){
            const string EMP1_NAME = "Test EMP 1";
            const double EMP1_ANUALSALARY = 20000;
            const double EMP1_ANUALTAX = 2400;
            IEmployee emp = new PermanentEmployee(EMP1_NAME, EMP1_ANUALSALARY);
            var cal = new Mock<ITaxCalculator>();
            cal.Setup(_ => _.CalculateIncomeTax(emp)).Returns(EMP1_ANUALTAX);            
            emp.TaxCalculator = cal.Object;
            PaySlipMonthly slip = new PaySlipMonthly(emp);
            Assert.Equal(slip.Name, EMP1_NAME);
            Assert.Equal(slip.GrossIncome, Math.Round(EMP1_ANUALSALARY/12,2));
            Assert.Equal(slip.IncomeTax, Math.Round(EMP1_ANUALTAX / 12, 2));
            Assert.Equal( EMP1_ANUALSALARY / 12 - EMP1_ANUALTAX / 12, slip.NetIncome, 2);

            Assert.Equal("Monthly Payslip for: \"Test EMP 1\"\nGross Monthly Income: $1666.67\nMonthly Income Tax $200\nNet Monthly Income $1466.67\n", slip.getDetails());
        }

        [Fact]
        public void ExceptionalCreationByMissingTaxCalculatorTest()
        {
            const string EMP1_NAME = "Test EMP 1";
            const double EMP1_ANUALSALARY = 20000;
            IEmployee emp = new PermanentEmployee(EMP1_NAME, EMP1_ANUALSALARY);
            Action actual = () => new PaySlipMonthly(emp);
            Assert.Throws<Exception>(actual);
        }
    }
}
