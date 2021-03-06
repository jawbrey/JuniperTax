using System;

namespace JuniperTax.Models
{
    public class Rate
    {
        public string zip { get; set; }
        public string state { get; set; }
        public string state_rate { get; set; }
        public string county { get; set; }
        public string county_rate { get; set; }
        public string city { get; set; }
        public string city_rate { get; set; }
        public string combined_district_rate { get; set; }
        public string combined_rate { get; set; }
        public bool freight_taxable { get; set; }
    }

    public class TaxJarRateWrapper
    {
        public Rate rate { get; set; }
    }
}

