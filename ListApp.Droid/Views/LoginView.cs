using System;
using Android.App;
using MvvmCross.Droid.Views;
using ListApp.Core;

namespace ListApp
{
<<<<<<< HEAD
<<<<<<< HEAD:ListApp.Droid/Views/LoginView.cs
<<<<<<< HEAD:ListApp.Droid/Views/LoginView.cs
	[Activity(Theme = "@android:style/Theme.Material.Light", Label = "ListApp", MainLauncher = true, HardwareAccelerated = true)]
	public class LoginView : MvxActivity
=======
=======
>>>>>>> origin/master:ListApp.Droid/Views/ListApp_DroidView.cs
	[Activity(Theme = "@android:style/Theme.Material.Light.NoActionBar", Label = "ListApp", HardwareAccelerated = true)]
	public class ListApp_DroidView : MvxActivity
>>>>>>> origin/master:ListApp.Droid/Views/ListApp_DroidView.cs
=======
	[Activity(Theme = "@android:style/Theme.Material.Light", Label = "ListApp", MainLauncher = true, HardwareAccelerated = true)]
	public class LoginView : MvxActivity
>>>>>>> parent of 5e001cf... Merge remote-tracking branch 'origin/master'
	{
		public new LoginViewModel ViewModel
		{
			get 
			{
				return (LoginViewModel)base.ViewModel; 
			}
			set 
			{ 
				base.ViewModel = value; 
			}
		}

		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.Login);
		}
	}
}

