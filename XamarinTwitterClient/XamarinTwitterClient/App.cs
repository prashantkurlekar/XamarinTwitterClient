using System;

using Xamarin.Forms;
using XamarinTwitterClient.Entities;
using XamarinTwitterClient.Pages;

namespace XamarinTwitterClient
{
    public class App
    {
        static NavigationPage _NavigationPage;
        public static UserDetails User;
        public static MessageListPage _MessageList;

        public static Page GetMainPage()
        {
            _MessageList = _MessageList ?? new MessageListPage();
            _NavigationPage = new NavigationPage(_MessageList);
            return _NavigationPage;
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                {
                    _NavigationPage.Navigation.PushModalAsync(_MessageList.GetTimeline());
                });
            }
        }
    }
}
