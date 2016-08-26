using System;
using Android.Webkit;
using System.Net;
using MvvmCross.Platform;
using Mono.Security.Interface;
using Android.App;
using System.Threading;
using ListApp.Core;
using MvvmCross.Core.ViewModels;
namespace ListApp
{
	public class CustomWebViewCLient : WebViewClient
	{
		public override void OnPageFinished(WebView view, string url)
		{
			base.OnPageFinished(view, url);
<<<<<<< HEAD
			//TODO перенести в сервис
<<<<<<< HEAD
			Core.Authorization.SetToken(view.Title);
=======
			//Core.Authorization.SetToken(view.Title);
>>>>>>> origin/settings
=======
			Mvx.Resolve<IAuthorization>().SetToken(view.Title);
>>>>>>> master
		}
	}
}

