using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
namespace ListApp.Core
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<LoginViewModel>());
		}
	}
}

