using System;
using JuniperTax.Interfaces;
using JuniperTax.Services;
using JuniperTax.Views;
using TinyIoC;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JuniperTax
{
    public partial class App : Application
    {
        public static TinyIoCContainer _container;

        public App ()
        {
            InitializeComponent();

            SetupIOC();

            MainPage = new CalcPage();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }

        private void SetupIOC()
        {
            // register the ITaxServiceClient to be used here
            // TODO: allow TaxService to determine on the fly 
            //var taxService = new TaxService(new FakeTaxServiceClient());
            var taxService = new TaxService(new TaxJarTaxServiceClient());

            _container = new TinyIoCContainer();
            _container.Register<ITaxService, TaxService>(taxService);
        }
    }
}

