using System;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
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
			Link = Authorization.CreateLink();
			base.Start();
		}

		//public void OnClick()
		//{
		//	Debug.WriteLine($"{ UserLogin } - { Password }");
		//	UserLogin = Password = string.Empty;
		//}


		//public MvxCommand Confirm { get { return new MvxCommand(OnClick); } }
	}
}