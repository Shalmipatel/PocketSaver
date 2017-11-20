using PocketSaver.Models;
using PocketSaver.Services;
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
    public partial class TransactionEditPage : ContentPage
    {
        string id;
        public TransactionEditPage()
        {
            InitializeComponent();
        }

        public TransactionEditPage(string tId, string category, string comment, DateTime date, Decimal purchaseAmount)
        {
            InitializeComponent();
            id = tId;
            categoryEntry.Text = category;
            commentEntry.Text = comment;
            purchaseAmountEntry.Text = Convert.ToString(purchaseAmount);
            dateEntry.Text = String.Format("{0:MM-dd-yyyy}", date);
            this.Title = comment + " - " + String.Format("{0:MMM d, yyyy}", date);
            delButton.IsVisible = true;
            delButton.IsEnabled = true;


        }


        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (categoryEntry.Text == null || commentEntry.Text == null || purchaseAmountEntry.Text == null || dateEntry.Text == null)
            {
                await DisplayAlert("Oops!", "One of the fields are empty, please try again!", "OK");
            } else
            {
                TransactionModel obj = new TransactionModel();
                obj.Category = categoryEntry.Text;
                obj.Comment = commentEntry.Text;
                obj.Date = Convert.ToDateTime(dateEntry.Text);
                obj.PurchaseAmount = Decimal.Parse(purchaseAmountEntry.Text);

                ApiSV sv = new ApiSV();
                sv.HttpBodyBuilder<TransactionModel>(obj);
                if (id == null)
                {
                    sv.url = sv.UrlBuilder("");
                    try
                    {
                        load.IsRunning = true;
                        await sv.Post<TransactionModel>();
                        load.IsRunning = false;
                        await DisplayAlert("Success!", "New transaction was created!", "OK");
                        await Navigation.PushAsync(new TransactionListPage());
                    }
                    catch
                    {
                        await DisplayAlert("Error", "Something went wrong with the API Call, Try Again!", "OK");
                        load.IsRunning = false;
                    }
                } else
                {
                    sv.url = sv.UrlBuilder("/" + id);
                    try
                    {
                        load.IsRunning = true;
                        await sv.Put<TransactionModel>();
                        load.IsRunning = false;
                        await DisplayAlert("Success!", "Transaction was edited!", "OK");
                        await Navigation.PushAsync(new TransactionListPage());
                    }
                    catch
                    {
                        await DisplayAlert("Error", "Something went wrong with the API Call, Try Again!", "OK");
                        load.IsRunning = false;
                    }
                }
            }

        }

        private async void delButton_Clicked(object sender, EventArgs e)
        {
            if (id != null)
            {
                ApiSV sv = new ApiSV();
                sv.url = sv.UrlBuilder("/" + id);
                var answer = await DisplayAlert("Wait!", "Are you sure you want to delete this transaction?", "YES", "NO");
                if (answer)
                {
                    try
                    {
                        load.IsRunning = true;
                        await sv.Delete<TransactionModel>();
                        load.IsRunning = false;
                        await DisplayAlert("Success!", "Transaction was deleted!", "OK");
                        await Navigation.PushAsync(new TransactionListPage());
                    }
                    catch
                    {
                        await DisplayAlert("Error", "Something went wrong with the API Call, Try Again!", "OK");
                        load.IsRunning = false;
                    }
                } else
                {
                    return;
                }
            }
        }

        private void categoryEntry_Completed(object sender, EventArgs e)
        {
            commentEntry.Focus();
        }

        private void commentEntry_Completed(object sender, EventArgs e)
        {
            purchaseAmountEntry.Focus();
        }

        private void purchaseAmountEntry_Completed(object sender, EventArgs e)
        {
            dateEntry.Focus();
        }

        private void dateEntry_Completed(object sender, EventArgs e)
        {
            saveButton_Clicked(sender, e);
        }

    }
}