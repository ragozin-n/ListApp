using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using Google.Apis.Auth.OAuth2;

namespace ListApp.Core
{
	public class Authorization : IAuthorization
	{
		public string Code { get; set; }

		public TokenJson Token { get; set; }

		public async Task SetToken(string html)
		{
			if (html.StartsWith("Success code=", StringComparison.CurrentCulture))
			{
				Code = html.Substring(13);
				await ConvertCodeToToken();
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

		private async Task ConvertCodeToToken()
		{
			using (var client = new HttpClient())
			{
				var values = new Dictionary<string, string>
				{
				   {"code", Code},
					{"client_id", "613151680037-0i0j493f9so3ioue2hmv62bnmahm8vae.apps.googleusercontent.com"},
					{"client_secret", "6FNxQ_r7CoE7pkPqLMcriNMm"},
					{"redirect_uri", "urn:ietf:wg:oauth:2.0:oob:auto"},
					{"grant_type", "authorization_code"},
				};

				var content = new FormUrlEncodedContent(values);

				var response = await client.PostAsync("https://www.googleapis.com/oauth2/v4/token", content);
				var responseString = await response.Content.ReadAsStringAsync();
				//TODO: Распарсить json
				Token = TokenJson.Deserialize(responseString);
			}
		}

		public async Task<string> GetUserInfo()
		{
			using (var client = new HttpClient())
			{
				var responce = await client.GetAsync($"https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token={Token.AccessToken}");
				var responceString = await responce.Content.ReadAsStreamAsync();

			}
			//var result = $"https://www.googleapis.com/oauth2/v1/userinfo?alt=json&access_token={Token.AccessToken}";
			//return result;
		}
	}
}

