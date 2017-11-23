using PocketSaver.ViewModels.HomePage;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomePageViewModel viewModel;
        public static ObservableCollection<String> monthList;


        public HomePage()
        {
            InitializeComponent();
            //HomePageViewModel.CalcMonth()
            viewModel = new HomePageViewModel();
            viewModel.CalcMonth();
            monthList = new ObservableCollection<string>();
            monthList.Add("Today");
            monthList.Add("January");
            monthList.Add("Febuary");
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
                            amount = Convert.ToString(viewModel.dailyTot);
                            Amount.Text = amount;
                            break;
                        case 1:
                            amount = Convert.ToString(viewModel.janTot);
                            Amount.Text = amount;
                            break;
                        case 2:
                            amount = Convert.ToString(viewModel.febTot);
                            Amount.Text = amount;
                            break;
                        case 3:
                            amount = Convert.ToString(viewModel.marTot);
                            Amount.Text = amount;
                            break;
                        case 4:
                            amount = Convert.ToString(viewModel.aprTot);
                            Amount.Text = amount;
                            break;
                        case 5:
                            amount = Convert.ToString(viewModel.mayTot);
                            Amount.Text = amount;
                            break;
                        case 6:
                            amount = Convert.ToString(viewModel.junTot);
                            Amount.Text = amount;
                            break;
                        case 7:
                            amount = Convert.ToString(viewModel.julTot);
                            Amount.Text = amount;
                            break;
                        case 8:
                            amount = Convert.ToString(viewModel.augTot);
                            Amount.Text = amount;
                            break;
                        case 9:
                            amount = Convert.ToString(viewModel.sepTot);
                            Amount.Text = amount;
                            break;
                        case 10:
                            amount = Convert.ToString(viewModel.octTot);
                            Amount.Text = amount;
                            break;
                        case 11:
                            amount = Convert.ToString(viewModel.novTot);
                            Amount.Text = amount;
                            break;
                        case 12:
                            amount = Convert.ToString(viewModel.decTot);
                            Amount.Text = amount;
                            break;
                        default:
                            Amount.Text = "Sorry Invalid Month Entered";
                            break;
                    }
                    //monthPicker.Text = (string)monthPicker.ItemsSource[selectedIndex];
                }
            };


        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //  await HomePageViewModel

            var monkeyNameLabel = new Label();
            monthPicker.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: monthList));
        }

        //void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        //{

        //    int selectedIndex = monthPicker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        switch (selectedIndex)
        //        {
        //            case 1: Amount.Text = "Test";
        //                    break;
        //            default: Amount.Text = "0.01";
        //                break;
        //        }
        //        //monthPicker.Text = (string)monthPicker.ItemsSource[selectedIndex];
        //    }

        //}


    }
}