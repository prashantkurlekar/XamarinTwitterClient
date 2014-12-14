using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTwitterClient.Pages
{
    public class BaseContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.User == null)
            {
                Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}
