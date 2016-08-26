using Android.App;
using ListApp.Core;
using MvvmCross.Droid.Views;

namespace ListApp
{
    [Activity(Theme = "@style/Theme.Custom", Label = "ListApp", MainLauncher = true, HardwareAccelerated = true)]
    public class Settings : MvxActivity
    {
        public new SettingsViewModel ViewModel
        {
            get { return (SettingsViewModel) base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.SettingsLayout);
        }
    }
}

