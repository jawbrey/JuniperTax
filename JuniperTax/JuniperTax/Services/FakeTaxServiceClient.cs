using System;
using System.Threading.Tasks;
using JuniperTax.Interfaces;

namespace JuniperTax.Services
{
	public class FakeTaxServiceClient : ITaxServiceClient
	{
        private const decimal TaxRate = 0.03m;
	
        public Task<decimal> GetRate(string zip)
        {
            return Task.FromResult<decimal>(TaxRate);
        }

        public Task<decimal> GetTax(string zip, decimal Taxable)
        {
            return Task.FromResult<decimal>(Taxable * TaxRate);
        }
    }
}

