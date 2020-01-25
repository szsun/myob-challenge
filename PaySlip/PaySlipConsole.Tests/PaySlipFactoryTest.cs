using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using PaySlipConsole.Model;
namespace PaySlipConsole.Tests
{
    public class PaySlipFactoryTest
    {
        

        [Fact]
        public void CreateMonthlyPaySlipTest()
        {
            const double EMP1_ANUALTAX = 2400;
            var employee = new Mock<IEmployee>();
            employee.Setup(_ => _.PaySlipPeriodType).Returns(PaySlipPeriodType.MONTHLY);
            var cal = new Mock<ITaxCalculator>();
            cal.Setup(_ => _.CalculateIncomeTax(employee.Object)).Returns(EMP1_ANUALTAX);            
            employee.Setup(_ => _.TaxCalculator).Returns(cal.Object);
            IPaySlip payslip = PaySlipFactory.generatePaySlip(employee.Object);
            Assert.True(payslip is PaySlipMonthly);
            
        }
        [Fact]
        public void CreateFornightlyPaySlipTest()
        {
            const double EMP1_ANUALTAX = 2400;
            var employee = new Mock<IEmployee>();
            employee.Setup(_ => _.PaySlipPeriodType).Returns(PaySlipPeriodType.FORNIGHTLY);
            var cal = new Mock<ITaxCalculator>();
            cal.Setup(_ => _.CalculateIncomeTax(employee.Object)).Returns(EMP1_ANUALTAX);
            employee.Setup(_ => _.TaxCalculator).Returns(cal.Object);
            IPaySlip payslip = PaySlipFactory.generatePaySlip(employee.Object);
            Assert.True(payslip is PaySlipFornightly);

        }
    }
}
