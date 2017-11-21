using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketSaver.Views.Transaction
{
    /// <summary>
    /// Class for the TransactionDetail page for the PocketSaver application.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionDetail : ContentPage
    {
        /// <summary>
        /// Declaring variables to be used throughout the TransactionDetail class.
        /// </summary>
        ObservableCollection<String> list = new ObservableCollection<String>();
        string dId, dCategory, dComment;
        DateTime dDate;
        Decimal dPurchaseAmount;

        /// <summary>
        /// Constructor for the TransactionDetail
        /// </summary>
        /// <param name="id">string id is the id retrieved from the database for the TransactionModel Object</param>
        /// <param name="category">string category is the category retrieved from the database for the TransactionModel Object</param>
        /// <param name="comment">string comment is the comment retrieved from the database for the TransactionModel Object</param>
        /// <param name="date">DateTime date is the date retrieved from the database for the TransactionModel Object</param>
        /// <param name="purchaseAmount">Decimal purchaseAmount is the purchase amount retrieved from the database for the TransactionModel Object</param>
        public TransactionDetail(String id, String category, String comment, DateTime date, Decimal purchaseAmount)
        {
            InitializeComponent();

            dId = id; dCategory = category; dComment = comment; dDate = date; dPurchaseAmount = purchaseAmount;

            list.Add("Category: " + category);
            list.Add("Comment: " + comment);
            list.Add("Purchase Amount: " + Convert.ToString(purchaseAmount));
            list.Add("Date: " + String.Format("{0:MMM d, yyyy}", date));

            this.Title = comment + " - " + String.Format("{0:MMM d, yyyy}", date);

            transactionDetail.ItemsSource = list;
            
        }

        /// <summary>
        /// Method used for when the Edit button is clicked
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">EventArgs e</param>
        private void editButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TransactionEditPage(dId, dCategory, dComment, dDate, dPurchaseAmount));
        }
    }
}