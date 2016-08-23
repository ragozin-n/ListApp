using System;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
using MvvmCross.Platform;

namespace ListApp.Core
{
	public class LoginViewModel : MvxViewModel
	{

		private string _link;

		public string Link
		{
			get { return _link; }
			set { _link = value; RaisePropertyChanged(() => Link); }
		}

		public override void Start()
		{
			var service = Mvx.Resolve<IAuthorization>();
			Link = service.CreateLink();
			service.TokenAlive += OnTokenAlive;
			base.Start();
		}

		private void OnTokenAlive(object sender, EventArgs e)
		{
			((IAuthorization)sender).TokenAlive -= OnTokenAlive;
			ShowViewModel<TaskListViewModel>();
		}

		 
		//public void OnClick()
		//{
		//	Debug.WriteLine($"{ UserLogin } - { Password }");
		//	UserLogin = Password = string.Empty;
		//}


		//public MvxCommand Confirm { get { return new MvxCommand(OnClick); } }
	}
}