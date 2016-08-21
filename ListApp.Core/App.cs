using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using ListApp.Core.ViewModels;

namespace ListApp.Core
{
	public class App : MvxApplication
	{
		public App()
		{
			Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<CreateTaskViewModel>());
		}
	}
}

