using System;
using System.Collections.Generic;
using System.Text;

namespace PaySlipConsole.Model
{
    /**
     * The income tax bucket defines the range and the rate.
     * eg.:
     * $18,201 – $37,000   19c for each $1 over $18,200
     */
    class TaxRateTie
    {
        public TaxRateTie(int min, int max, double rate)
        {
            Min = min;
            Max = max;
            Rate = rate;
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public double Rate { get; set; }

    }
}
