using System;

using UIKit;
using MvvmCross.iOS.Views;
using ListApp.Core;
using Foundation;
using System.Diagnostics;

namespace ListApp.iOS
{
	public partial class LoginView : MvxViewController<LoginViewModel>
	{
		public LoginView() : base("LoginView", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			var uri = new Uri(Authorization.CreateLink());
			var nsurl = new NSUrl(uri.GetComponents(UriComponents.HttpRequestUrl, UriFormat.UriEscaped));
			LoginWebView.LoadRequest(new NSUrlRequest(nsurl));
			LoginWebView.LoadFinished += (sender, e) => Authorization.SetToken(LoginWebView.EvaluateJavascript("document.title"));
		}
			
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


