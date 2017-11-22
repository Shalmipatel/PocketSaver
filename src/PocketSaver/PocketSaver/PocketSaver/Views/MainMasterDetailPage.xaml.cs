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
        /// <summary>
        /// Method for when an object in a list is selected.
        /// </summary>
        /// <param name="sender">Sender Object</param>
        /// <param name="e">SelectedItemChangedEventArgs e</param>
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

        /// <summary>
        /// Method to navigate to a new page.
        /// </summary>
        /// <param name="page">Page page which is an instance of a new Class.</param>
        public void NavigateTo(Page page)
        {
            Detail = new NavigationPage(page);
        }
    }
}
