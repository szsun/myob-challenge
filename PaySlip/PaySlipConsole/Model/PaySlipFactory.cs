using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    /**
     * Payroll cycle
     */
    public enum PaySlipPeriodType { 
        YEARLY, MONTHLY, FORNIGHTLY, WEEKLY
    }
    /**
     * Payroll location where the corresponding tax regulation is applied.
     */
    public enum PaySlipLocation
    {
        AU, NZ, CN, US
    }

    /**
     * Payroll financial year in which the tax ties may vary.
     */
    public enum PaySlipFY
    {
        FY18, FY19, FY20, FY21
    }

    /**
     *  The factory to create the payslip based on the employee's PaySlipPeriodType attribute.
     */
    public class PaySlipFactory
    {
        public static IPaySlip generatePaySlip(IEmployee employee)
        {
            IPaySlip ps = null;
            switch (employee.PaySlipPeriodType)
            {
                case PaySlipPeriodType.MONTHLY: ps = new PaySlipMonthly(employee);break;
                case PaySlipPeriodType.FORNIGHTLY: ps = new PaySlipFornightly(employee); break;
            }
            return ps;
        }
    }
}
