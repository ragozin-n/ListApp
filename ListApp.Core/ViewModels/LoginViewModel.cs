﻿using System;
using MvvmCross.Core.ViewModels;
using System.Diagnostics;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace ListApp.Core
{
	public class LoginViewModel : MvxViewModel
	{

		private string _link;

		[MvxInject]
		public IAuthorization Authorization { get; set; }

		public string Link
		{
			get { return _link; }
			set { _link = value; RaisePropertyChanged(() => Link); }
		}

		public override void Start()
		{
			Link = Authorization.CreateLink();
			Authorization.TokenAlive += OnTokenAlive;
			base.Start();
		}

		private void OnTokenAlive(object sender, EventArgs e)
		{
			Authorization.TokenAlive -= OnTokenAlive;
			//var result = Authorization.GetUserInfo();
			Link = Authorization.GetUserInfo();
			//Close(this);
			//ShowViewModel<TaskListViewModel>();
		}

		 
		//public void OnClick()
		//{
		//	Debug.WriteLine($"{ UserLogin } - { Password }");
		//	UserLogin = Password = string.Empty;
		//}


		//public MvxCommand Confirm { get { return new MvxCommand(OnClick); } }
	}
}