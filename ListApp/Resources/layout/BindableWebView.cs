using System;
using Android.Content;
using Android.Util;
using Android.Webkit;
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
				if (string.IsNullOrEmpty(value)) return;

				_url = value;

				Settings.SetPluginState(WebSettings.PluginState.On);
				Settings.JavaScriptEnabled = true;
				SetWebViewClient(new WebViewClient());
				LoadUrl(_url);
				UpdatedHtmlContent();
			}
		}

		public event EventHandler HtmlContentChanged;

		private void UpdatedHtmlContent()
		{
			var handler = HtmlContentChanged;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}
	}
}

