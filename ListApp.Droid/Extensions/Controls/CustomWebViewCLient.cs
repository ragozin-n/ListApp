using System;
using Android.Webkit;
using System.Net;
using MvvmCross.Platform;
namespace ListApp
{
	public class CustomWebViewCLient : WebViewClient
	{
		public override void OnPageFinished(WebView view, string url)
		{
			base.OnPageFinished(view, url);
			//TODO перенести в сервис
<<<<<<< HEAD
			Core.Authorization.SetToken(view.Title);
=======
			//Core.Authorization.SetToken(view.Title);
>>>>>>> origin/settings
		}
	}
}

