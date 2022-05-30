using System;
using System.Threading.Tasks;
using JuniperTax.Interfaces;

namespace JuniperTax.Services
{
    public class TaxService : ITaxService
    {
        private ITaxServiceClient taxServiceClient;

        public TaxService(ITaxServiceClient client)
        {
            this.taxServiceClient = client;
        }

        public Task<decimal> GetRate(string zip)
        {
            return taxServiceClient.GetRate(zip);
        }

        public Task<decimal> GetTax(string zip, decimal Taxable)
        {
            return taxServiceClient.GetTax(zip, Taxable);
        }
    }
}

