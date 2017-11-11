using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketSaver.Views.Shared
{
    /// <summary>
    /// Class for the PageActivityIndicator.
    /// </summary>
    public class PageActivityIndicator : StackLayout
    {
        public bool Activated = true;
        public static readonly BindableProperty RunningProperty = BindableProperty.Create(
            propertyName: "Running",
            returnType: typeof(bool),
            declaringType: typeof(PageActivityIndicator),
            defaultValue: true,
            propertyChanged: RunningChanged);
        public bool Running
        {
            get { return (bool)GetValue(RunningProperty); }
            set { SetValue(RunningProperty, value); }
        }


        ActivityIndicator activityIndicator = new ActivityIndicator();
        public PageActivityIndicator()
        {
            BackgroundColor = Color.FromRgba(0, 0, 0, 0.1);
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            //Opacity = 0;
            IsVisible = Running;
            //Activated = !Running;

            activityIndicator.HorizontalOptions = LayoutOptions.Center;
            activityIndicator.VerticalOptions = LayoutOptions.CenterAndExpand;
            activityIndicator.IsRunning = Running;

            Children.Add(activityIndicator);
        }

        private static async void RunningChanged(object bindable, object oldValue, object newValue)
        {
            var activityIndicator = bindable as PageActivityIndicator;

            if ((bool)newValue)
            {
                await activityIndicator.Begin();
            }
            else
            {
                await activityIndicator.End();
            }
        }

        public async Task Begin()
        {
            if (this.Activated == false)
            {
                this.Activated = true;
                this.Opacity = 0;
                this.IsVisible = true;
                await this.FadeTo(1, 250, Easing.Linear);
            }
        }

        public async Task End()
        {
            if (this.Activated)
            {
                await this.FadeTo(0, 250, Easing.Linear);
                this.IsVisible = false;
                this.Activated = false;
            }
        }
    }
}
