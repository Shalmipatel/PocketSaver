using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PocketSaver.Views.Transaction
{
    public class TransactionListCell : ViewCell
    {
        //Creating labels within the view cell that can be used and accessed.
        Label titleNW = new Label();
        Label subTitleNW = new Label();
        Label titleNE = new Label();
        Label subTitleNE = new Label();
        Label titleSW = new Label();
        Label subTitleSW = new Label();
        Label titleSE = new Label();
        Label subTitleSE = new Label();

        //Bindable properties needed for this view cell
        public static readonly BindableProperty CategoryProperty =
            BindableProperty.Create("Category", typeof(string), typeof(TransactionListCell), "Category");
        public static readonly BindableProperty CommentProperty =
            BindableProperty.Create("Comment", typeof(string), typeof(TransactionListCell), "Comment");
        public static readonly BindableProperty DateProperty =
            BindableProperty.Create("Date", typeof(DateTime?), typeof(TransactionListCell), null);
        public static readonly BindableProperty PurchaseAmountProperty =
            BindableProperty.Create("PurchaseAmount", typeof(decimal), typeof(TransactionListCell), 0.00m);

        //Attributes that are associated with the bindable properties
        public string Category
        {
            get { return (string)GetValue(CategoryProperty); }
            set { SetValue(CategoryProperty, value); }
        }
        public string Comment
        {
            get { return (string)GetValue(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }
        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }
        public decimal PurchaseAmount
        {
            get { return (decimal)GetValue(PurchaseAmountProperty); }
            set { SetValue(PurchaseAmountProperty, value); }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if(BindingContext != null)
            {
                titleNW.Text = Comment;
                titleNE.Text = "Category: " + Category;
                titleSW.Text = "Date: " + String.Format("{0:MMM d, yyyy}", Date);
                titleSE.Text = "Purchase Amount: $" + string.Format("{0:f2}", PurchaseAmount);
            }
        }

        public TransactionListCell()
        {
            var grid = new Grid
            {
                ColumnSpacing = 0,
                RowSpacing = 0,
                Padding = new Thickness(10, 5),
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                }
            };


            //Set properties for labels

            titleNW.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            titleNW.TextColor = Color.Black;
            subTitleNW.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));

            titleNE.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            titleNE.TextColor = Color.Black;
            titleNE.HorizontalTextAlignment = TextAlignment.End;
            titleNE.VerticalTextAlignment = TextAlignment.Center;

            subTitleNE.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            subTitleNE.HorizontalTextAlignment = TextAlignment.End;
            subTitleNE.VerticalTextAlignment = TextAlignment.Start;

            titleSW.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            subTitleSW.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            subTitleSW.VerticalTextAlignment = TextAlignment.End;

            titleSE.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            titleSE.HorizontalTextAlignment = TextAlignment.End;
            subTitleSE.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label));
            subTitleSE.HorizontalTextAlignment = TextAlignment.End;


            // Add views to grid, and set column spans

            grid.Children.Add(titleNW, 0, 0);
            Grid.SetColumnSpan(titleNW, 2);
            grid.Children.Add(subTitleNW, 0, 1);
            Grid.SetColumnSpan(subTitleNW, 2);

            grid.Children.Add(titleNE, 2, 0);
            grid.Children.Add(subTitleNE, 2, 1);

            grid.Children.Add(titleSW, 0, 2);
            Grid.SetColumnSpan(titleSW, 2);
            grid.Children.Add(subTitleSW, 0, 3);
            Grid.SetColumnSpan(subTitleSW, 2);

            grid.Children.Add(titleSE, 2, 2);
            grid.Children.Add(subTitleSE, 2, 3);

            View = grid;
        }
    }
}
