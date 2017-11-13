using PocketSaver.ViewModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketSaver.Views.Transaction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionListPage : ContentPage
    {
        TransactionViewModel viewModel;

        public TransactionListPage()
        {
            InitializeComponent();

            viewModel = new TransactionViewModel();
            //activityIndicator.BindingContext = viewModel;

        }

        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    await activityIndicator.Begin();
        //    await TransactionViewModel.RefreshList();
        //    transactionList.ItemsSource = TransactionViewModel.transactionDatum;
        //    BindingContext = viewModel;
        //    await activityIndicator.End();
        //}

        private async Task b1_ClickedAsync(object sender, EventArgs e)
        {
            await TransactionViewModel.RefreshList();

        }
    }
}