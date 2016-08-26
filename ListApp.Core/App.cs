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
<<<<<<< HEAD
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<SettingsViewModel>());
=======
			Mvx.RegisterSingleton<IAuthorization>(new Authorization());
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());
>>>>>>> master
		}
	}
}

