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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionDetail : ContentPage
    {
        ObservableCollection<String> list = new ObservableCollection<String>();

        string dId, dCategory, dComment;
        DateTime dDate;
        Decimal dPurchaseAmount;

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

        private void editButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TransactionEditPage(dId, dCategory, dComment, dDate, dPurchaseAmount));
        }
    }
}