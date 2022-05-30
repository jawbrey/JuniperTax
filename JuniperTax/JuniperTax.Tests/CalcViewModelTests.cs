using FakeItEasy;
using JuniperTax.Interfaces;
using JuniperTax.ViewModels;
using NUnit.Framework;

namespace JuniperTax.Tests
{
    public class CalcViewModelTests
    {
        ITaxService svc;

        [SetUp]
        public void Setup()
        {
            svc = A.Fake<ITaxService>();
            A.CallTo(() => svc.GetRate("77379")).Returns(.0825m);
            A.CallTo(() => svc.GetRate("22152")).Returns(.06m);
        }

        [Test]
        [TestCase(null,null)]
        [TestCase(null, "0")]
        [TestCase("0", null)]
        [TestCase("000", "10")]
        [TestCase("77379", "-10")]
        [TestCase("77379", "0")]
        public void TestInvalidInputs(string zip, string taxable)
        {
            var vm = new CalcViewModel(svc);

            vm.Zip = zip;
            vm.Taxable = taxable;

            vm.ValidateAndCalculate();

            Assert.AreEqual(0, vm.Tax);
            Assert.AreEqual(0, vm.Rate);
            Assert.AreEqual(0, vm.Total);
        }

        [Test]
        [TestCase("77379", "11", .0825, .91, 11.91)]
        [TestCase("77379", "121", .0825, 9.98, 130.98)]
        [TestCase("77379", "1120.21", .0825, 92.42, 1212.63)]
        [TestCase("22152", "11", .06, .66, 11.66)]
        [TestCase("22152", "121", .06, 7.26, 128.26)]
        [TestCase("22152", "1120.21", .06, 67.21, 1187.42)]
        public void TestValidInputs(string zip, string taxable, decimal rate, decimal tax, decimal total)
        {
            var vm = new CalcViewModel(svc);

            vm.Zip = zip;
            vm.Taxable = taxable;

            vm.ValidateAndCalculate();

            Assert.AreEqual(rate, vm.Rate);
            Assert.AreEqual(tax, vm.Tax);
            Assert.AreEqual(total, vm.Total);
        }
    }
}
