using System;
using Android.App;
using MvvmCross.Droid.Views;
using ListApp.Core;

namespace ListApp
{
	[Activity(Theme = "@android:style/Theme.Material.Light", Label = "ListApp"/*, MainLauncher = true*/)]
	public class ListApp_DroidView : MvxActivity
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

