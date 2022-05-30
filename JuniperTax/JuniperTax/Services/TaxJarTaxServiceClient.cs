using System;
using System.Threading.Tasks;
using JuniperTax.Interfaces;
using JuniperTax.Models;
using Refit;

namespace JuniperTax.Services
{
	public class TaxJarTaxServiceClient : ITaxServiceClient
    {
        ITaxJarAPI taxJar;

		public TaxJarTaxServiceClient()
		{
            taxJar = RestService.For<ITaxJarAPI>("https://api.taxjar.com");
        }

        public async Task<decimal> GetRate(string zip)
        {
            var result = await taxJar.GetRate(zip);

            return decimal.Parse(result.rate.combined_rate);
        }

        public async Task<decimal> GetTax(string zip, decimal Taxable)
        {
            var request = new
            {
                to_country = "US",
                to_zip = zip,
                amount = Taxable,
                shipping = 0,
                to_state = "TX",
            };

            TaxJarTaxWrapper result = null;
            
            try
            {
                result = await taxJar.GetTax(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return (decimal)result.tax.amount_to_collect;
        }
    }
}

