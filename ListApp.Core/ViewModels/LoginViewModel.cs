using System;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
namespace ListApp.Core
{
	public class LoginViewModel : MvxViewModel
	{

		private string _userLogin;

		public string UserLogin
		{
			get { return _userLogin; }
			set { _userLogin = value; RaisePropertyChanged(() => UserLogin); }
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set { _password = value; RaisePropertyChanged(() => Password); }
		}

		public override void Start()
		{
			UserLogin = Password = string.Empty;
			base.Start();
		}
		public void OnClick()
		{
			Debug.WriteLine($"{ UserLogin } - { Password }");
			UserLogin = Password = string.Empty;
		}


		public MvxCommand Confirm { get { return new MvxCommand(OnClick); } }
	}
}