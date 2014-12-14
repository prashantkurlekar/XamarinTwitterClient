using System;

using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinTwitterClient.iOS.Pages;
using XamarinTwitterClient.Pages;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace XamarinTwitterClient.iOS.Pages
{
	public class LoginPageRenderer : PageRenderer
	{
		bool showLogin = true;
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (showLogin && App.User == null)
			{
				showLogin = false;

				//Twitter with oauth1 
				var auth = new OAuth1Authenticator(
					consumerKey: "Twitter Consumer Key",
                    consumerSecret: "Twitter Consumer Secret",
					requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"), // the redirect URL for the service
					authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"), // the auth URL for the service
					accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
					callbackUrl: new Uri("http://twitter.com")
				);

				auth.Completed += (sender, eventArgs) =>
				{
					DismissViewController(true, null);

					if (eventArgs.IsAuthenticated)
					{
						App.User = new Entities.UserDetails();
						// Use eventArgs.Account to do wonderful things
						App.User.Token = eventArgs.Account.Properties["oauth_token"];
						App.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
						App.User.TwitterId = eventArgs.Account.Properties["user_id"];
						App.User.ScreenName = eventArgs.Account.Properties["screen_name"];

						//Store details for future use, 
						//so we don't have to promt authentication screen everytime
						AccountStore.Create().Save(eventArgs.Account, "Twitter");

						App.SuccessfulLoginAction.Invoke();
					}
					//else
					//{
					//    // The user cancelled
					//}
				};

				PresentViewController(auth.GetUI(), true, null);
			}
		}
	}
}
