using Android.App;
using Android.Widget;
using Android.OS;
using MvvmCross.Droid.Platform;
using Android.Content;
using MvvmCross.Core.ViewModels;

namespace ListApp
{
	public class Setup : MvxAndroidSetup
	{
		public Setup(Context applicationContext) : base(applicationContext)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}


	}
}


