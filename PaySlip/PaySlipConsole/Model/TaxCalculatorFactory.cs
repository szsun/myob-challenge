using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    /**
     * TaxCaculatorFactory is using Singleton pattern so that only one instance is needed.
     * it also uses the factory pattern to create ITaxCaculator based on location and financial year.
     * 
     */
    public sealed class TaxCalculatorFactory
    {
        private static readonly TaxCalculatorFactory instance = new TaxCalculatorFactory();
        static TaxCalculatorFactory()
        {

        }
        private TaxCalculatorFactory()
        {

        }
        public static TaxCalculatorFactory Instance
        {
            get{
                return instance;
            }
        }
        /**
         * the creation of tax calculator can be extended to a service that checks the employee's location, FY etc. 
         * 
         */
        public ITaxCalculator GetTaxCalculator(PaySlipLocation location, PaySlipFY FY)
        {
            ITaxCalculator taxCal = null;
            if (location == PaySlipLocation.AU && FY == PaySlipFY.FY19)
            {
                taxCal = new TaxCalculator_AU_FY19();
            }
            else { 
                //TODO: for other country and year
            }
            return taxCal;
        }
    }
}
