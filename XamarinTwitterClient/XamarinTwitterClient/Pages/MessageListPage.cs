using Xamarin.Forms;
using XamarinTwitterClient.Services;

namespace XamarinTwitterClient.Pages
{
    public class MessageListPage : BaseContentPage
    {
        public MessageListPage()
        {
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        XAlign = TextAlignment.Center,
                        Text = "Welcome to Xamarin!!"
                    }
                }
            };
        }

        public Page GetTimeline()
        {
            var listView = new ListView
            {
                RowHeight = 50
            };

            listView.ItemsSource = TwitterService.Search();
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Value");

            return new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Children = { listView }
                }
            };
        }
    }
}
