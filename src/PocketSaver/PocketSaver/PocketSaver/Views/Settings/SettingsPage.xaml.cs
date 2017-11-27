using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketSaver.Views.Settings
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
        private object text;
        public static String budgetAmount;

        public SettingsPage ()
		{
			InitializeComponent ();

            var MyEntry = new Entry { Text = "I am an Entry" };
            var text = MyEntry.Text;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
           

            
        }

        private void Enter_Clicked(Object sender, EventArgs e )
        {

            budgetAmount = budgetValue.Text;
        }
    }
}