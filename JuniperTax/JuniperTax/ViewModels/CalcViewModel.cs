using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using JuniperTax.Interfaces;
using Xamarin.Forms;

namespace JuniperTax.ViewModels
{
	public class CalcViewModel : INotifyPropertyChanged
	{
		private ITaxService taxService;

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand ValidateAndCalculateCommand { get; set; }

		public string Zip { get; set; }
		public string Taxable { get; set; }
		public decimal Total { get; set; }
		public decimal Tax { get; set; }
		public decimal Rate { get; set; }

		public CalcViewModel(ITaxService taxService = null)
		{
			if (taxService != null)
			{
				this.taxService = taxService;
			}
			else
			{
				this.taxService = App._container.Resolve<ITaxService>();
			}

			ValidateAndCalculateCommand = new Command(execute: ValidateAndCalculate);
		}

		public async void ValidateAndCalculate()
        {
			decimal taxable;

			if (!decimal.TryParse(Taxable, out taxable))
            {
				await DisplayAlert("Error", "Please enter a valid value for Amount!", "OK");
				Clear();
				return;
            }

			if (taxable <= 0)
			{
				await DisplayAlert("Error", "Please enter a valid positive value for Amount!", "OK");
				Clear();
				return;
			}

			// TODO: actually check for valid ZIP, not just valid format
			// regex for zip/zip+4 (https://www.oreilly.com/library/view/regular-expressions-cookbook/9781449327453/ch04s14.html)
			string zipPattern = "^[0-9]{5}(?:-[0-9]{4})?$";

			if (string.IsNullOrEmpty(Zip) || !Regex.IsMatch(Zip, zipPattern))
            {
				await DisplayAlert("Error", "Please enter a valid ZIP or ZIP+4!", "OK");
				Clear();
				return;
			}

			try
			{
				this.Rate = await taxService.GetRate(Zip);
			}
			catch (Exception ex)
            {
				// TODO: not a user friendly message
				await DisplayAlert("Error", $"An error occured: {ex.Message}", "OK");
				Clear();
				return;
			}

			//this.Tax = await taxService.GetTax(Zip, taxable);
			this.Tax = Math.Round(taxable * Rate,2);
			this.Total = taxable + Tax;
        }

		public async Task DisplayAlert(string title, string message, string button)
        {
			if (App.Current?.MainPage != null)
			{
				await App.Current.MainPage.DisplayAlert(title, message, button);
			}
        }

		public void Clear()
        {
			this.Rate = 0m;
			this.Tax = 0m;
			this.Total = 0m;
		}
	}
}

