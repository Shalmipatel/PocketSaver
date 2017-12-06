using PocketSaver.Services;
using PocketSaver.ViewModels.HomePage;
using PocketSaver.Views.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketSaver.Views.Home
{
    /// <summary>
    /// Class for the HomePage View.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        /// <summary>
        /// Creating variables to be used in the class.
        /// </summary>
        public static ObservableCollection<String> monthList;

        /// <summary>
        /// Constructor for the HomePage View.
        /// </summary>
        public HomePage()
        {
            InitializeComponent();

            //Populating the picker.
            monthList = new ObservableCollection<string>();
            monthList.Add("Today");
            monthList.Add("January");
            monthList.Add("February");
            monthList.Add("March");
            monthList.Add("April");
            monthList.Add("May");
            monthList.Add("June");
            monthList.Add("July");
            monthList.Add("August");
            monthList.Add("September");
            monthList.Add("October");
            monthList.Add("November");
            monthList.Add("December");
            monthPicker.Title = "Select a Month";
            monthPicker.ItemsSource = monthList;

            monthPicker.SelectedIndexChanged += (sender, e) =>
            {
                String amount;
                if (monthPicker.SelectedIndex != -1)
                {

                    switch (monthPicker.SelectedIndex)
                    {
                        case 0:
                            amount = "$" + Convert.ToString(HomePageViewModel.dailyTot);
                            Amount.Text = amount;
                            break;
                        case 1:
                            amount = "$" + String.Format("{0:f2}", Convert.ToString(HomePageViewModel.janTot));
                            Amount.Text = amount;
                            break;
                        case 2:
                            amount = "$" + Convert.ToString(HomePageViewModel.febTot);
                            Amount.Text = amount;
                            break;
                        case 3:
                            amount = "$" + Convert.ToString(HomePageViewModel.marTot);
                            Amount.Text = amount;
                            break;
                        case 4:
                            amount = "$" + Convert.ToString(HomePageViewModel.aprTot);
                            Amount.Text = amount;
                            break;
                        case 5:
                            amount = "$" + Convert.ToString(HomePageViewModel.mayTot);
                            Amount.Text = amount;
                            break;
                        case 6:
                            amount = "$" + Convert.ToString(HomePageViewModel.junTot);
                            Amount.Text = amount;
                            break;
                        case 7:
                            amount = "$" + Convert.ToString(HomePageViewModel.julTot);
                            Amount.Text = amount;
                            break;
                        case 8:
                            amount = "$" + Convert.ToString(HomePageViewModel.augTot);
                            Amount.Text = amount;
                            break;
                        case 9:
                            amount = "$" + Convert.ToString(HomePageViewModel.sepTot);
                            Amount.Text = amount;
                            break;
                        case 10:
                            amount = "$" + Convert.ToString(HomePageViewModel.octTot);
                            Amount.Text = amount;
                            break;
                        case 11:
                            amount = "$" + Convert.ToString(HomePageViewModel.novTot);
                            Amount.Text = amount;
                            break;
                        case 12:
                            amount = "$" + Convert.ToString(HomePageViewModel.decTot);
                            Amount.Text = amount;
                            break;
                        default:
                            Amount.Text = "Sorry Invalid Month Entered";
                            break;
                    }
                }
            };
        }

        /// <summary>
        /// OnAppearing method that calls ViewModel to prepare totals.
        /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            load.IsRunning = true;
            await HomePageViewModel.CalcMonth();
            load.IsRunning = false;
            remainingBudget.Text = Convert.ToString("$" + HomePageViewModel.currentMonth);

            var Label = new Label();
            monthPicker.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: monthList));

            
        }
    }
}