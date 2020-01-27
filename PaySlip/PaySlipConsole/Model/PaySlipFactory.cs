using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
   
    /**
     *  The factory to create the payslip based on the employee's PaySlipPeriodType attribute.
     */
    public class PaySlipFactory
    {
        public static IPaySlip CreatePaySlip(IEmployee employee)
        {
            IPaySlip ps = null;
            switch (employee.PaySlipPeriodType)
            {
                case PaySlipPeriodType.MONTHLY: ps = new PaySlipMonthly(employee); break;
                case PaySlipPeriodType.FORNIGHTLY: ps = new PaySlipFornightly(employee); break;
            }
            return ps;
        }
    }
}
