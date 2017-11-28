using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace PocketSaver.ViewModels
{
    /// <summary>
    /// Class for the AboutViewModel
    /// </summary>
    public class AboutViewModel : BaseViewModel
    {
        /// <summary>
        /// Constructor for the AboutViewModel which creates a web command.
        /// </summary>
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
