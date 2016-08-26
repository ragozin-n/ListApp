using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MvvmCross.Droid.Views;
using ListApp.Core;
using MvvmCross.Binding.Droid.Views;

namespace ListApp.Views
{
    [Activity(Theme = "@android:style/Theme.Material.Light", Label = "@string/app_name", MainLauncher = true)]
    public class TaskList_DroidView : MvxActivity
    {
        public new TaskListViewModel ViewModel
        {
            get {return (TaskListViewModel)base.ViewModel; }
            set {base.ViewModel = value;}
        }

		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.TaskList);
		}
    }
}