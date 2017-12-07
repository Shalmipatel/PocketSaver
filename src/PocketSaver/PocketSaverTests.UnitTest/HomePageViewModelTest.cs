using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocketSaver.ViewModels.HomePage;
using PocketSaver.Services;

namespace PocketSaverTests.UnitTest
{
    /// <summary>
    /// Summary description for HomePageViewModelTest
    /// </summary>
    [TestClass]
    public class HomePageViewModelTest
    {


        [TestMethod]
        public async System.Threading.Tasks.Task TestMonthlyTotalAsync()
        {
            await HomePageViewModel.CalcMonth();
            Assert.IsTrue(Decimal.Compare(HomePageViewModel.novTot, Convert.ToDecimal(204.28)) == 0);
            Assert.IsTrue(Decimal.Compare(HomePageViewModel.decTot, Convert.ToDecimal(75.00)) == 0);
            Assert.IsTrue(Decimal.Compare(HomePageViewModel.febTot, Convert.ToDecimal(52.76)) == 0);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestDailyTotalAsync()
        {
            await HomePageViewModel.CalcMonth();
            Assert.IsTrue(Decimal.Compare(HomePageViewModel.dailyTot, Convert.ToDecimal(75.00)) == 0);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task TestRemainingBudget()
        {
            await HomePageViewModel.CalcMonth();
            Assert.IsTrue(Decimal.Compare(HomePageViewModel.currentMonth, Convert.ToDecimal(923.75)) < 0);

        }
    }
}
