using PocketSaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PocketSaver.Views
{
    /// <summary>
    /// Class for the MasterDetail page.
    /// </summary>
    public partial class MainMasterDetailPage : MasterDetailPage
    {
        /// <summary>
        /// Constructor for the MainMasterDetailPage.
        /// </summary>
		public MainMasterDetailPage()
        {
            InitializeComponent();

            MainMenuPage.ListView.ItemSelected += OnItemSelected;
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                switch (item.Title)
                {
                    default:
                        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                        break;
                }
                MainMenuPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

        public void NavigateTo(Page page)
        {
            Detail = new NavigationPage(page);
        }
    }
}