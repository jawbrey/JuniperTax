using System;
using System.Threading.Tasks;

namespace JuniperTax.Interfaces
{
	public interface ITaxServiceClient
	{

		Task<decimal> GetRate(string zip);
		Task<decimal> GetTax(string zip, decimal Taxable);
	}
}

