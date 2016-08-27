using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Google.Apis.Auth.OAuth2.Flows;

namespace ListApp.Core
{
	public class App : MvxApplication
	{
		public App()
		{

			Mvx.RegisterSingleton<IAuthorization>(new Authorization());
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());
		}
	}
}

