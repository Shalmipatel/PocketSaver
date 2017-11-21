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

    /// <summary>
    /// Class for the TransactionListPage of the PocketSaver Mobile Application.
    /// </summary>
    public partial class TransactionListPage : ContentPage
    {
        /// <summary>
        /// Declaring the TransactionViewModel object.
        /// </summary>
        TransactionViewModel viewModel;

        /// <summary>
        /// Constructor for the TransactionListPage which initializes the TransactionViewModel and defines the listview item selection.
        /// </summary>
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
        /// <summary>
        /// OnAppearing Method which is used to declare variables and methods to be called upon the page appearing.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            load.IsRunning = true;
            await TransactionViewModel.RefreshList();
            transactionList.ItemsSource = TransactionViewModel.transactionDatum;
            load.IsRunning = false;
            BindingContext = viewModel;
            
        }

        /// <summary>
        /// Method for the addButton when clicked which creates a new TransactionEditPage.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">EventArgument</param>
        private void addButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TransactionEditPage());

        }
    }
}