using PocketSaver.Views.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketSaver.Helpers
{
    /// <summary>
    /// Class for a Custom ImageCell that allows for tinted images.
    /// </summary>
    public class CustomImageCell : ViewCell
    {
        //Setting the variables required for the class.
        TintedImage image = new TintedImage();
        Label text = new Label();
        Grid grid = new Grid();

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(CustomImageCell), "");
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomImageCell), "");
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(CustomImageCell), Color.Black);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(CustomImageCell), Color.Black);

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                image.Source = ImageSource;
                image.TintColor = TintColor;
                text.Text = Text;
                text.TextColor = TextColor;
            }
        }

        CustomImageCell()
        {
            grid.ColumnSpacing = 0;
            grid.RowSpacing = 0;
            grid.VerticalOptions = LayoutOptions.Center;
            grid.HorizontalOptions = LayoutOptions.StartAndExpand;
            grid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition { Height = GridLength.Auto }
            };

            image.Margin = new Thickness(10, 5, 20, 5);
            text.VerticalTextAlignment = TextAlignment.Center;
            text.FontSize = 20;
            grid.Children.Add(image, 0, 0);
            grid.Children.Add(text, 1, 0);
            Grid.SetColumnSpan(text, 4);
            this.View = grid;
        }
    }
}
