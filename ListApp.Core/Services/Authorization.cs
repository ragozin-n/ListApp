using System;
//using Google.Apis.Auth.OAuth2;

namespace ListApp.Core
{
	public class Authorization : IAuthorization
	{
		public static string Token { get; set; }

		public bool SetToken(string html)
		{
			if (html.StartsWith("Success code=", StringComparison.CurrentCulture))
			{
				Token = html.Substring(12);
				return true;
			}
			return false;
		}

		public string CreateLink()
		{
			return string.Format(
				@"https://accounts.google.com/o/oauth2/auth?" +
				@"display=popup" +
				@"&scope=email profile" +
				@"&redirect_uri=urn:ietf:wg:oauth:2.0:oob:auto" +
				@"&response_type=code" +
				@"&client_id=613151680037-0i0j493f9so3ioue2hmv62bnmahm8vae.apps.googleusercontent.com");
		}
	}
}

