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
    /// <summary>
    /// Class for the TransactionEditPage for the PocketSaver Mobile.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionEditPage : ContentPage
    {
        /// <summary>
        /// Declaring variable id to be used throughout the class.
        /// </summary>
        string id;

        /// <summary>
        /// Constructor for the TransactionEditPage
        /// </summary>
        public TransactionEditPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor overload for the TransactionEditPage.
        /// </summary>
        /// <param name="tId">string tId is the id retrieved from the database for the TransactionModel Object</param>
        /// <param name="category">string category is the category retrieved from the database for the TransactionModel Object</param>
        /// <param name="comment">string comment is the comment retrieved from the database for the TransactionModel Object</param>
        /// <param name="date">DateTime date is the date retrieved from the database for the TransactionModel Object</param>
        /// <param name="purchaseAmount">Decimal purchaseAmount is the purchase amount retrieved from the database for the TransactionModel Object</param>
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

        /// <summary>
        /// Method for when the Save button is clicked.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">EventArgs e</param>
        private async void saveButton_Clicked(object sender, EventArgs e)
        {
            if (categoryEntry.Text == null || commentEntry.Text == null || purchaseAmountEntry.Text == null || dateEntry.Text == null)
            {
                await DisplayAlert("Oops!", "One of the fields are empty, please try again!", "OK");
            }
            else
            {
                TransactionModel obj = new TransactionModel();
                try
                {
                    obj.Category = categoryEntry.Text;
                    obj.Comment = commentEntry.Text;
                    obj.Date = Convert.ToDateTime(dateEntry.Text);
                    obj.PurchaseAmount = Decimal.Parse(purchaseAmountEntry.Text);
                }
                catch
                {
                    await DisplayAlert("Oops!", "One of the input parameters is not in the correct format, Please try again!", "OK");
                    load.IsRunning = false;
                    return;
                }

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
                        await Navigation.PopToRootAsync();
                    }
                    catch
                    {
                        await DisplayAlert("Error", "Something went wrong with the API Call, Try Again!", "OK");
                        load.IsRunning = false;
                    }
                }
                else
                {
                    sv.url = sv.UrlBuilder("/" + id);
                    try
                    {
                        load.IsRunning = true;
                        await sv.Put<TransactionModel>();
                        load.IsRunning = false;
                        await DisplayAlert("Success!", "Transaction was edited!", "OK");
                        await Navigation.PopToRootAsync();
                    }
                    catch
                    {
                        await DisplayAlert("Error", "Something went wrong with the API Call, Try Again!", "OK");
                        load.IsRunning = false;
                    }
                }
            }

        }

        /// <summary>
        /// Mehod for the Delete button clicked event.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">EventArgs e</param>
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
                        await Navigation.PopToRootAsync();
                    }
                    catch
                    {
                        await DisplayAlert("Error", "Something went wrong with the API Call, Try Again!", "OK");
                        load.IsRunning = false;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Method for when the categoryEntry is completed to shift the entry's focus to another entry
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">EventArgs e</param>
        private void categoryEntry_Completed(object sender, EventArgs e)
        {
            commentEntry.Focus();
        }

        /// <summary>
        /// Method for when the commentEntry is completed to shift the entry's focus to another entry
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">EventArgs e</param>
        private void commentEntry_Completed(object sender, EventArgs e)
        {
            purchaseAmountEntry.Focus();
        }

        /// <summary>
        /// Method for when the purchaseAmountEntry is completed to shift the entry's focus to another entry
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">EventArgs e</param>
        private void purchaseAmountEntry_Completed(object sender, EventArgs e)
        {
            dateEntry.Focus();
        }

        /// <summary>
        /// Method for when the dateEntry is completed to shift the entry's focus to another entry
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">EventArgs e</param>
        private void dateEntry_Completed(object sender, EventArgs e)
        {
            saveButton_Clicked(sender, e);
        }

        private void TodayButton_Clicked(object sender, EventArgs e)
        {
            dateEntry.Text = String.Format("{0:MM-dd-yyyy}", DateTime.Today);
        }
    }
}
