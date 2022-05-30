using System;
using System.Threading.Tasks;
using JuniperTax.Models;
using Refit;

namespace JuniperTax.Interfaces
{
	public interface ITaxJarAPI
	{
		[Headers("Authorization: Bearer 5da2f821eee4035db4771edab942a4cc")]
		[Get("/v2/rates/{zip}")]
		Task<TaxJarRateWrapper> GetRate(string Zip);

		[Headers("Authorization: Bearer 5da2f821eee4035db4771edab942a4cc")]
		[Post("/v2/taxes")]
		Task<TaxJarTaxWrapper> GetTax([Body] object request);
		
	}
}

