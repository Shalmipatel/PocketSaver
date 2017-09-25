using PocketSaver.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Title = "About",
                IconSource = "calendar_2.png",
                TargetType = typeof(AboutPage),
                TintColor = Color.DodgerBlue,
                TextColor = Color.Black
            });
            

            masterPageItems.Add(modulesGroup);
            listView.ItemsSource = masterPageItems;
        }
    }
}