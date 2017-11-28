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
                    viewModel = new HomePageViewModel();
                    switch (monthPicker.SelectedIndex)
                    {
                        case 0:
                            amount = "$" + Convert.ToString(viewModel.dailyTot);
                            Amount.Text = amount;
                            break;
                        case 1:
                            amount = "$" + Convert.ToString(viewModel.janTot);
                            Amount.Text = amount;
                            break;
                        case 2:
                            amount = "$" + Convert.ToString(viewModel.febTot);
                            Amount.Text = amount;
                            break;
                        case 3:
                            amount = "$" + Convert.ToString(viewModel.marTot);
                            Amount.Text = amount;
                            break;
                        case 4:
                            amount = "$" + Convert.ToString(viewModel.aprTot);
                            Amount.Text = amount;
                            break;
                        case 5:
                            amount = "$" + Convert.ToString(viewModel.mayTot);
                            Amount.Text = amount;
                            break;
                        case 6:
                            amount = "$" + Convert.ToString(viewModel.junTot);
                            Amount.Text = amount;
                            break;
                        case 7:
                            amount = "$" + Convert.ToString(viewModel.julTot);
                            Amount.Text = amount;
                            break;
                        case 8:
                            amount = "$" + Convert.ToString(viewModel.augTot);
                            Amount.Text = amount;
                            break;
                        case 9:
                            amount = "$" + Convert.ToString(viewModel.sepTot);
                            Amount.Text = amount;
                            break;
                        case 10:
                            amount = "$" + Convert.ToString(viewModel.octTot);
                            Amount.Text = amount;
                            break;
                        case 11:
                            amount = "$" + Convert.ToString(viewModel.novTot);
                            Amount.Text = amount;
                            break;
                        case 12:
                            amount = "$" + Convert.ToString(viewModel.decTot);
                            Amount.Text = amount;
                            break;
                        default:
                            Amount.Text = "Sorry Invalid Month Entered";
                            break;



                    }
                }
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //  await HomePageViewModel

            var Label = new Label();
            monthPicker.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: monthList));

            int month = DateTime.Now.Month;
            decimal currentMonth;
            switch (month)
            {
                case 1:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.janTot;
                    break;
                case 2:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.febTot;
                    break;
                case 3:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.marTot;
                    break;
                case 4:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.aprTot;
                    break;
                case 5:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.mayTot;
                    break;
                case 6:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.junTot;
                    break;
                case 7:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.julTot;
                    break;
                case 8:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.augTot;
                    break;
                case 9:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.sepTot;
                    break;
                case 10:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.octTot;
                    break;
                case 11:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.novTot;
                    break;
                case 12:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - viewModel.decTot;
                    break;
                default:
                    currentMonth = Convert.ToDecimal(StorageSV.BudgetAmount) - 0;
                    break;
            }

            // budget.Text = SettingsPage.budgetAmount;
            remainingBudget.Text = Convert.ToString(currentMonth);

        }
    }
}