using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        Text = "Message List"
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
