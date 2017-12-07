using PocketSaver.Models;
using PocketSaver.Services;
using PocketSaver.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketSaver.ViewModels.HomePage
{
    /// <summary>
    /// Class for the HomePageViewModel
    /// </summary>
    public class HomePageViewModel
    {
        /// <summary>
        /// Creating variables to be used in the class.
        /// </summary>
        public static decimal janTot = 0.00m;
        public static decimal febTot = 0.00m;
        public static decimal marTot = 0.00m;
        public static decimal aprTot = 0.00m;
        public static decimal mayTot = 0.00m;
        public static decimal junTot = 0.00m;
        public static decimal julTot = 0.00m;
        public static decimal augTot = 0.00m;
        public static decimal sepTot = 0.00m;
        public static decimal octTot = 0.00m;
        public static decimal novTot = 0.00m;
        public static decimal decTot = 0.00m; 
        public static decimal dailyTot = 0.00m;
        public static decimal currentMonth;

        public static ObservableCollection<TransactionModel> transactionDatum = new ObservableCollection<TransactionModel>();

        /// <summary>
        /// Method to calculate monthly totals and budgets as well as daily totals.
        /// </summary>
        /// <returns>Task T</returns>
        public static async Task CalcMonth()
        {
            //Calling API
            transactionDatum.Clear();
            janTot = 0.00m;
            febTot = 0.00m;
            marTot = 0.00m;
            aprTot = 0.00m;
            mayTot = 0.00m;
            junTot = 0.00m;
            julTot = 0.00m;
            augTot = 0.00m;
            sepTot = 0.00m;
            octTot = 0.00m;
            novTot = 0.00m;
            decTot = 0.00m;
            dailyTot = 0.00m;
            ApiSV sv = new ApiSV();

            sv.url = sv.UrlBuilder(sv.QueryBuilder("{}", "&sort=Date&dir=-1"));

            try
            {
                List<TransactionModel> allData = await sv.Get<List<TransactionModel>>();

                foreach (var x in allData) { transactionDatum.Add(x); }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Could not pull data", Convert.ToString(ex.Message), "OK");

            }

            //Calculating monthly totals.
            foreach (var x in transactionDatum)
            {
                if (x.Date.Year == DateTime.Now.Year)
                {

                    switch (x.Date.Month)
                    {
                        case 1:
                            janTot += x.PurchaseAmount;
                            break;
                        case 2:
                            febTot += x.PurchaseAmount;
                            break;
                        case 3:
                            marTot += x.PurchaseAmount;
                            break;
                        case 4:
                            aprTot += x.PurchaseAmount;
                            break;
                        case 5:
                            mayTot += x.PurchaseAmount;
                            break;
                        case 6:
                            junTot += x.PurchaseAmount;
                            break;
                        case 7:
                            julTot += x.PurchaseAmount;
                            break;
                        case 8:
                            augTot += x.PurchaseAmount;
                            break;
                        case 9:
                            sepTot += x.PurchaseAmount;
                            break;
                        case 10:
                            octTot += x.PurchaseAmount;
                            break;
                        case 11:
                            novTot += x.PurchaseAmount;
                            break;
                        case 12:
                            decTot += x.PurchaseAmount;
                            break;
                        default:
                            break;
                    }
                }
                //Calculating daily totals.
                if(x.Date.Day == DateTime.Now.Day)
                {
                    dailyTot += x.PurchaseAmount;
                }
            }
            //Calculating monthly budget.
            if (!StorageSV.BudgetAmount.Equals("0.00"))
            {
                switch (DateTime.Now.Month)
                {
                    case 1:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.janTot;
                        break;
                    case 2:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.febTot;
                        break;
                    case 3:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.marTot;
                        break;
                    case 4:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.aprTot;
                        break;
                    case 5:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.mayTot;
                        break;
                    case 6:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.junTot;
                        break;
                    case 7:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.julTot;
                        break;
                    case 8:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.augTot;
                        break;
                    case 9:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.sepTot;
                        break;
                    case 10:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.octTot;
                        break;
                    case 11:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.novTot;
                        break;
                    case 12:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.decTot;
                        break;
                    default:
                        currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - 0;
                        break;
                }
            }
            else
            {
                currentMonth = Convert.ToDecimal("0.00");
            }
        }

    }
}
