using Android.App;

using System;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinTwitterClient.Droid.Pages;
using XamarinTwitterClient.Pages;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace XamarinTwitterClient.Droid.Pages
{
	public class LoginPageRenderer : PageRenderer
	{
		bool showLogin = true;
		protected override void OnElementPropertyChanged(object s, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(s, e);

			var activity = this.Context as Activity;

			if (showLogin && App.User == null)
			{
				showLogin = false;

				//Twitter with oauth1 
				var auth = new OAuth1Authenticator(
					consumerKey: "Twitter Consumer Key",
					consumerSecret: "Twitter Consumer Secret",
					// the redirect URL for the service
					requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), 
					// the auth URL for the service
					authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), 
					accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
					// callback url must be to a page where the URL does not change during navigation
					callbackUrl: new Uri("https://mobile.twitter.com")
				);

				auth.Completed += async (sender, eventArgs) =>
				{
					await Element.Navigation.PopModalAsync();

					if (eventArgs.IsAuthenticated)
					{
						App.User = new Entities.UserDetails();
						// Use eventArgs.Account to do wonderful things
						App.User.Token = eventArgs.Account.Properties["oauth_token"];
						App.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
						App.User.TwitterId = eventArgs.Account.Properties["user_id"];
						App.User.ScreenName = eventArgs.Account.Properties["screen_name"];

						App.SuccessfulLoginAction.Invoke();
					}
					//else
					//{
					//    // The user cancelled
					//}
				};

				activity.StartActivity(auth.GetUI(activity));
			}
		}
	}
}