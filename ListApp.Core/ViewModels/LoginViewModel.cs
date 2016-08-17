using System;
using MvvmCross.Core.ViewModels;
namespace ListApp.Core
{
	public class LoginViewModel : MvxViewModel
	{
		public string UserLogin { get; set; }
		public string Password { get; set; }

		public override void Start()
		{
			UserLogin = Password = string.Empty;
			base.Start();
		}
	}
}

