using System;
using System.Collections.Generic;

namespace JuniperTax.Models
{
    
    public class Breakdown
    {
        public int taxable_amount { get; set; }
        public double tax_collectable { get; set; }
        public double combined_tax_rate { get; set; }
        public int state_taxable_amount { get; set; }
        public double state_tax_rate { get; set; }
        public double state_tax_collectable { get; set; }
        public int county_taxable_amount { get; set; }
        public double county_tax_rate { get; set; }
        public double county_tax_collectable { get; set; }
        public int city_taxable_amount { get; set; }
        public int city_tax_rate { get; set; }
        public int city_tax_collectable { get; set; }
        public int special_district_taxable_amount { get; set; }
        public double special_tax_rate { get; set; }
        public double special_district_tax_collectable { get; set; }
        public List<LineItem> line_items { get; set; }
    }

    public class Jurisdictions
    {
        public string country { get; set; }
        public string state { get; set; }
        public string county { get; set; }
        public string city { get; set; }
    }

    public class LineItem
    {
        public string id { get; set; }
        public int taxable_amount { get; set; }
        public double tax_collectable { get; set; }
        public double combined_tax_rate { get; set; }
        public int state_taxable_amount { get; set; }
        public double state_sales_tax_rate { get; set; }
        public double state_amount { get; set; }
        public int county_taxable_amount { get; set; }
        public double county_tax_rate { get; set; }
        public double county_amount { get; set; }
        public int city_taxable_amount { get; set; }
        public int city_tax_rate { get; set; }
        public int city_amount { get; set; }
        public int special_district_taxable_amount { get; set; }
        public double special_tax_rate { get; set; }
        public double special_district_amount { get; set; }
    }

    public class TaxJarTaxWrapper
    {
        public Tax tax { get; set; }
    }

    public class Tax
    {
        public double order_total_amount { get; set; }
        public double shipping { get; set; }
        public int taxable_amount { get; set; }
        public double amount_to_collect { get; set; }
        public double rate { get; set; }
        public bool has_nexus { get; set; }
        public bool freight_taxable { get; set; }
        public string tax_source { get; set; }
        public Jurisdictions jurisdictions { get; set; }
        public Breakdown breakdown { get; set; }
    }
}

