using PocketSaver.Models;
using PocketSaver.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketSaver.ViewModels.Transaction
{
    public class TransactionViewModel : INotifyPropertyChanged
    {
        private bool isRefreshingProperty = true;
        public bool isRefreshing
        {
            get { return isRefreshingProperty; }
            set
            {
                isRefreshingProperty = value;
                NotifyPropertyChanged("isRefreshing");
            }
        }

        public static ObservableCollection<TransactionModel> transactionDatum = new ObservableCollection<TransactionModel>();

        public static async Task RefreshList()
        {
            transactionDatum.Clear();
            ApiSV sv = new ApiSV();

            sv.url = sv.UrlBuilder("");

            try
            {
                List<TransactionModel> allData = await sv.Get<List<TransactionModel>>();

                foreach (var x in allData) { transactionDatum.Add(x); }
            } 
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Could not pull data", Convert.ToString(ex.Message), "OK");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }


    }
}
