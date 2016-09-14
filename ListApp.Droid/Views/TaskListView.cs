using Android.App;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Platform;
using ListApp.Core;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using System;
using ListApp.Core.ViewModels;
using Android.Widget;
using Android.Database;
using Android.Views;
using Java.Lang;

namespace ListApp.Views
{
    [Activity(Theme = "@android:style/Theme.Material.Light", Label = "@string/app_name", MainLauncher = true)]
    public class TaskList_DroidView : MvxActivity
    {
		DrawerLayout drLayout;
		ActionBarDrawerToggle leftMenu;

        public new TaskListViewModel ViewModel
        {
            get {return (TaskListViewModel)base.ViewModel; }
            set {base.ViewModel = value;}
        }

		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.TaskList);
			drLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);
			leftMenu = new ActionBarDrawerToggle(this, drLayout, Resource.String.left_menu, Resource.String.unknow);
			drLayout.SetDrawerListener(leftMenu);
			ActionBar.SetDisplayHomeAsUpEnabled(true);
			ActionBar.SetHomeButtonEnabled(true);
			var listLeft = FindViewById<ListView>(Resource.Id.ListActionBar);
		}

		protected override void OnPostCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnPostCreate(savedInstanceState);
			leftMenu.SyncState();
		}
    }
}