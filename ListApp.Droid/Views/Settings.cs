using System;
using Android.App;
using MvvmCross.Droid.Views;
using ListApp.Core;

namespace ListApp
{
	[Activity(Theme = "@android:style/Theme.Material.Light.NoActionBar", Label = "ListApp", MainLauncher = true, HardwareAccelerated = true)]
	public class Settings : MvxActivity
	{
		public new SettingsViewModel ViewModel
		{
			get
			{
				return (SettingsViewModel)base.ViewModel;
			}
			set
			{
				base.ViewModel = value;
			}

		}

		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.Settings);
		}


	}
}

