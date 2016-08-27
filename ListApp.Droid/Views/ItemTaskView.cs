using System;
using Android.App;
using MvvmCross.Droid.Views;
using ListApp.Core;

namespace ListApp
{
	public class ItemTaskView : MvxActivity
	{
		public new ItemTaskView ViewModel
		{
			get { return (ItemTaskView)base.ViewModel; }
			set { base.ViewModel = (MvvmCross.Core.ViewModels.IMvxViewModel)value; }
		}

		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.ItemTask);
		}
	}
}

