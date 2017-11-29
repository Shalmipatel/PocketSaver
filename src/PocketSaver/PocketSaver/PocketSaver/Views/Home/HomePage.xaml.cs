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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomePageViewModel viewModel;
        public static ObservableCollection<String> monthList;
        decimal currentMonth;
        decimal nov;

        public HomePage()
        {
            InitializeComponent();

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
                            amount = "$" + Convert.ToString(HomePageViewModel.dailyTot);
                            Amount.Text = amount;
                            break;
                        case 1:
                            amount = "$" + Convert.ToString(HomePageViewModel.janTot);
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
                            nov = HomePageViewModel.novTot;
                            amount = "$" + Convert.ToString(nov);
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

            int month = DateTime.Now.Month;
            
            switch (month)
            {
                case 1:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.janTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 2:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.febTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 3:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.marTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 4:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.aprTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 5:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.mayTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 6:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.junTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 7:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.julTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 8:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.augTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 9:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.sepTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 10:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.octTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 11:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.novTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                case 12:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - HomePageViewModel.decTot;
                    remainingBudget.Text = Convert.ToString("$" + currentMonth);
                    break;
                default:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - 0;
                    break;
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            viewModel = new HomePageViewModel();
            viewModel.CalcMonth();

            var Label = new Label();
            monthPicker.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: monthList));

            
        }
    }
}