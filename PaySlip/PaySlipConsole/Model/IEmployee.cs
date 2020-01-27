using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    /**
     * Payroll cycle
     */
    public enum PaySlipPeriodType
    {
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
     *  This interface is to provide the standard attributes for all types of employee.
     *  employee implementation can be specific to a certain type , eg, permanent, contract, partime, casual etc.
     */
    public interface IEmployee
    {
        public string DisplayName { get; set; }

        public double AnualSalary { get; set; }

        public PaySlipPeriodType PaySlipPeriodType { get; set; }
        public PaySlipLocation PaySlipLocation { get; set; }
        public ITaxCalculator TaxCalculator { get; set; }

        // extended attributes eg. location/country,
    }
}
