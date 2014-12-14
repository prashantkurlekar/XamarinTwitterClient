using Microsoft.Phone.Controls;

using Xamarin.Forms;


namespace XamarinTwitterClient.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = XamarinTwitterClient.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
