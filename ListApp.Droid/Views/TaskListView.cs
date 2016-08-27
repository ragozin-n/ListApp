using Android.App;
using MvvmCross.Droid.Views;
using ListApp.Core;

namespace ListApp.Views
{
    [Activity(Theme = "@android:style/Theme.Material.Light", Label = "@string/app_name")]
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