using System;
using Newtonsoft.Json;
namespace ListApp.Core
{
	public class TokenJson
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }

		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }

		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		public static TokenJson Deserialize(string json)
		{
			return JsonConvert.DeserializeObject<TokenJson>(json);
		}
	}
}

