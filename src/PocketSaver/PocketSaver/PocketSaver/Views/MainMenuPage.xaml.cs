using PocketSaver.Models;
using PocketSaver.Views.Home;
using PocketSaver.Views.Settings;
using PocketSaver.Views.Transaction;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketSaver.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    /// <summary>
    /// Class for the MainMenu page.
    /// </summary>
    public partial class MainMenuPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        private ObservableCollection<GroupedMasterPageItem> masterPageItems { get; set; }

        /// <summary>
        /// Constructor for the MainMenu page.
        /// </summary>
        public MainMenuPage()
        {
            InitializeComponent();

            masterPageItems = new ObservableCollection<GroupedMasterPageItem>();
            var modulesGroup = new GroupedMasterPageItem() { Grouping = "Modules" };
            var systemGroup = new GroupedMasterPageItem() { Grouping = "System" };

            modulesGroup.Add(new MasterPageItem
            {
                Title = "Home",
                IconSource = "home.png",
                TargetType = typeof(HomePage),
                TintColor = Color.DodgerBlue,
                TextColor = Color.Black
            });

            modulesGroup.Add(new MasterPageItem
            {
                Title = "Transaction Summary",
                IconSource = "coin_bank_note.png",
                TargetType = typeof(TransactionListPage),
                TintColor = Color.LimeGreen,
                TextColor = Color.Black
            });

            systemGroup.Add(new MasterPageItem
            {
                Title = "About",
                IconSource = "information_circle.png",
                TargetType = typeof(AboutPage),
                TintColor = Color.Black,
                TextColor = Color.Black
            });

            systemGroup.Add(new MasterPageItem
            {
                Title = "Settings",
                IconSource = "cog.png",
                TargetType = typeof(SettingsPage),
                TintColor = Color.DimGray,
                TextColor = Color.Black
            });


            masterPageItems.Add(modulesGroup); masterPageItems.Add(systemGroup);
            listView.ItemsSource = masterPageItems;
        }
    }
}