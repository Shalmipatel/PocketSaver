using PocketSaver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketSaver.Views.Settings
{
    /// <summary>
    /// Class for the SettingsPage View.
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{

        /// <summary>
        /// Constructor for the SettingsPage.
        /// </summary>
        public SettingsPage ()
		{
			InitializeComponent ();

            var MyEntry = new Entry { Text = "I am an Entry" };
            var text = MyEntry.Text;
            budgetAmount.Text = StorageSV.BudgetAmount;
        }

        /// <summary>
        /// Method for the Enter button being clicked.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">EventArgs e</param>
        private void Enter_Clicked(Object sender, EventArgs e )
        {

            StorageSV.BudgetAmount = String.Format("{0:f2}", budgetValue.Text);
        }
    }
}