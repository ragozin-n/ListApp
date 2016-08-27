using Android.App;
using MvvmCross.Droid.Views;
using ListApp.Core;

namespace ListApp
{
	[Activity(Theme = "@android:style/Theme.Material.Light", Label = "ListApp", MainLauncher = true, HardwareAccelerated = true)]
	public class LoginView : MvxActivity

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

