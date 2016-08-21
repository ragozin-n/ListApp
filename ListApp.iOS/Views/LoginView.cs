using System;

using UIKit;
using MvvmCross.iOS.Views;
using ListApp.Core;
using Foundation;

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
			LoginWebView.LoadRequest(new NSUrlRequest(new NSUrl(Authorization.CreateLink())));

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


