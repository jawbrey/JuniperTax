using System;
using System.Collections.Generic;
using JuniperTax.ViewModels;
using Xamarin.Forms;

namespace JuniperTax.Views
{	
	public partial class CalcPage : ContentPage
	{
		private CalcViewModel ViewModel { get; set; }

		public CalcPage ()
		{
			InitializeComponent ();

			this.BindingContext = ViewModel = new CalcViewModel();
		}
	}
}

