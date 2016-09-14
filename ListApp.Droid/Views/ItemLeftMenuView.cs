using MvvmCross.Droid.Views;

namespace ListApp
{
	public class ItemLeftMenuView : MvxActivity
	{
		public new ItemLeftMenuView ViewModel
		{
			get { return (ItemLeftMenuView)base.ViewModel; }
			set { base.ViewModel = (MvvmCross.Core.ViewModels.IMvxViewModel)value; }
		}
 		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.ItemLeftMenu);
		}

	}
}

