using System.Threading.Tasks;
using FakeItEasy;
using JuniperTax.Interfaces;
using JuniperTax.Services;
using JuniperTax.ViewModels;
using NUnit.Framework;

namespace JuniperTax.Tests
{
    public class TaxServiceTests
    {
        ITaxServiceClient client;

        [SetUp]
        public void Setup()
        {
            client = A.Fake<ITaxServiceClient>();
            A.CallTo(() => client.GetRate("77379")).Returns(.0825m);
            A.CallTo(() => client.GetRate("22152")).Returns(.06m);
        }

        [Test]
        [TestCase("77379", .0825)]
        [TestCase("22152", .06)]
        public async Task GetRateTest(string zip, decimal expected)
        {
            var svc = new TaxService(client);

            Task<decimal> task = svc.GetRate(zip);
            task.Wait();
            var rate = task.Result;

            Assert.AreEqual(expected, rate);
        }

    }
}
