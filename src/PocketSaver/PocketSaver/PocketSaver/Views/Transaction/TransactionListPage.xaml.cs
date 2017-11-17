using PocketSaver.Models;
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

            transactionList.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                {
                    return;
                }
                TransactionModel selected = e.SelectedItem as TransactionModel;
                Navigation.PushAsync(new TransactionDetail(selected._id, selected.Category, selected.Comment, selected.Date, selected.PurchaseAmount));
                transactionList.SelectedItem = null;

            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            load.IsRunning = true;
            await TransactionViewModel.RefreshList();
            transactionList.ItemsSource = TransactionViewModel.transactionDatum;
            load.IsRunning = false;
            BindingContext = viewModel;
            
        }

        private void addButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TransactionEditPage());

        }
    }
}