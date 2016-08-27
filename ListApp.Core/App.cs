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
<<<<<<< HEAD

=======
<<<<<<< HEAD
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<SettingsViewModel>());
=======
>>>>>>> origin/master
=======
>>>>>>> parent of 5e001cf... Merge remote-tracking branch 'origin/master'
			Mvx.RegisterSingleton<IAuthorization>(new Authorization());
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());
>>>>>>> master
		}
	}
}

