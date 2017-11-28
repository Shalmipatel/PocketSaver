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
    /// <summary>
    /// Class for the TransactionViewModel.
    /// </summary>
    public class TransactionViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Declaring variables to be used throughout the class
        /// </summary>
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

        /// <summary>
        /// Instantiating the observable collection of TransactionModels
        /// </summary>
        public static ObservableCollection<TransactionModel> transactionDatum = new ObservableCollection<TransactionModel>();

        /// <summary>
        /// Method used to refresh the transactionList.
        /// </summary>
        /// <returns></returns>
        public static async Task RefreshList()
        {
            transactionDatum.Clear();
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
        }

        /// <summary>
        /// Declaring the Bindable property for the isRefreshing property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
}
