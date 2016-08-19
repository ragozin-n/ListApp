using System;
using Android.Webkit;
using System.Net;
namespace ListApp
{
	public class CustomWebViewCLient : WebViewClient
	{
		public override void OnPageFinished(WebView view, string url)
		{
			base.OnPageFinished(view, url);
			Core.Authorization.GetToken();
		}
	}
}

