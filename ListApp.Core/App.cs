using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Google.Apis.Auth.OAuth2.Flows;
using ListApp.Core.ViewModels;

namespace ListApp.Core
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterSingleton<IAuthorization>(new Authorization());
			//28.08.16: Точка входа приложения - авторизация.
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());
		}
	}
}

