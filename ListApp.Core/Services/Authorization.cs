using System;
using System.Collections.Generic;
using System.Net.Http;
//using Google.Apis.Auth.OAuth2;

namespace ListApp.Core
{
	public class Authorization : IAuthorization
	{
		public string Token { get; set; }

		public void SetToken(string html)
		{
			if (html.StartsWith("Success code=", StringComparison.CurrentCulture))
			{
				Token = html.Substring(12);
				TokenAlive?.Invoke(this, new EventArgs());
			}
		}

		public string CreateLink()
		{
			return string.Format(
				@"https://accounts.google.com/o/oauth2/auth?" +
				@"display=popup" +
				@"&scope=profile" +
				@"&redirect_uri=urn:ietf:wg:oauth:2.0:oob:auto" +
				@"&response_type=code" +
				@"&client_id=613151680037-0i0j493f9so3ioue2hmv62bnmahm8vae.apps.googleusercontent.com");
		}

		public event EventHandler TokenAlive;

		private async void ConvertCodeToToken()
		{
			using (var client = new HttpClient())
			{
				var values = new Dictionary<string, string>
				{
				   {"code", Token},
					{"client_id", "613151680037-0i0j493f9so3ioue2hmv62bnmahm8vae.apps.googleusercontent.com"},
					{"client_secret", "6FNxQ_r7CoE7pkPqLMcriNMm"},
					{"redirect_uri", "urn:ietf:wg:oauth:2.0:oob:auto"},
					{"grant_type", "authorization_code"},
				};

				var content = new FormUrlEncodedContent(values);

				var response = await client.PostAsync("https://www.googleapis.com/oauth2/v4/token", content);

				var responseString = await response.Content.ReadAsStringAsync();
				//TODO: Распарсить json
			}
		}
	}
}

