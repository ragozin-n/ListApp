using System;
namespace ListApp.Core
{
	public interface IAuthorization
	{
		/// <summary>
		/// Creates the authorization link to open in browser.
		/// </summary>
		/// <returns>Authorization link.</returns>
		string CreateLink();

		/// <summary>
		/// Parse token from page's tittle and save it.
		/// </summary>
		/// <returns>Token's availability.</returns>
		void SetToken(string html);

		event EventHandler TokenAlive;
	}
}

