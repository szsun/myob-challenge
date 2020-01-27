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
            var employee = new Mock<IEmployee>();
            employee.Setup(_ => _.PaySlipPeriodType).Returns(PaySlipPeriodType.MONTHLY);
            IPaySlip payslip = PaySlipFactory.CreatePaySlip(employee.Object);
            Assert.True(payslip is PaySlipMonthly);
            
        }
        [Fact]
        public void CreateFornightlyPaySlipTest()
        {
            var employee = new Mock<IEmployee>();
            employee.Setup(_ => _.PaySlipPeriodType).Returns(PaySlipPeriodType.FORNIGHTLY);            
            IPaySlip payslip = PaySlipFactory.CreatePaySlip(employee.Object);
            Assert.True(payslip is PaySlipFornightly);

        }
        [Fact]
        public void CreateNullPaySlipTest()
        {
            var employee = new Mock<IEmployee>();
            employee.Setup(_ => _.PaySlipPeriodType).Returns(PaySlipPeriodType.WEEKLY);
            IPaySlip payslip = PaySlipFactory.CreatePaySlip(employee.Object);
            Assert.True(payslip is null);
        }
    }
}
