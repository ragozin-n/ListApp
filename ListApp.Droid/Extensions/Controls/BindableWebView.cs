using System;
using Android.Content;
using Android.Util;
using Android.Webkit;
using Java.Lang;
using MvvmCross.Binding.Bindings.SourceSteps;
namespace ListApp
{
	public class BindableWebView : WebView
	{
		private string _url;

		public BindableWebView(Context context, IAttributeSet attrs)
			: base(context, attrs)
		{
		}

		public string TargetUrl
		{
			get { return _url; }
			set
			{
				if (Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute)) return;

				_url = value;

				Settings.SetPluginState(WebSettings.PluginState.On);
				Settings.JavaScriptEnabled = true;
				SetWebViewClient(new CustomWebViewCLient());
				LoadUrl(_url);
			}
		}
	}
}

