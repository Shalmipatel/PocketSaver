namespace PocketSaver.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadApplication(new PocketSaver.App());
        }
    }
}