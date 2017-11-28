using PocketSaver.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketSaver.ViewModels.HomePage
{
    public class HomePageViewModel
    {
        public static decimal janTot;
        public static decimal febTot;
        public static decimal marTot;
        public static decimal aprTot;
        public static decimal mayTot;
        public static decimal junTot;
        public static decimal julTot;
        public static decimal augTot;
        public static decimal sepTot;
        public static decimal octTot;
        public static decimal novTot;
        public static decimal decTot;
        public static decimal dailyTot;

        public HomePageViewModel()
        {
            janTot = 0;
            febTot = 0;
            marTot = 0;
            aprTot = 0;
            mayTot = 0;
            junTot = 0;
            julTot = 0;
            augTot = 0;
            sepTot = 0;
            octTot = 0;
            novTot = 0;
            decTot = 0;
            dailyTot = 0;


        }

        public async void CalcMonth()
        {
            await TransactionViewModel.RefreshList();

            foreach (var x in TransactionViewModel.transactionDatum)
            {
                switch (x.Date.Month){
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

                if(x.Date.Day == DateTime.Now.Day)
                {
                    dailyTot += x.PurchaseAmount;
                }

            }

            

        }

    }
}
