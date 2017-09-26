using PocketSaver.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PocketSaver
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new MainMasterDetailPage();
        }

        public static Page GetMainPage()
        {
            var mainNav = new NavigationPage(new MainMasterDetailPage());
            return mainNav;
        }
    }
}
