using System;
using System.Linq;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ListApp.Core.ViewModels;

namespace ListApp.Core
{
	public class ItemLeftMenuViewModel : MvxViewModel
	{
		public ItemLeftMenuViewModel(string name, ICommand action)
		{
			Name = name;
			Action = action;
		}
		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; RaisePropertyChanged(() => Name); }
		}
		private ICommand _action;

		public ICommand Action
		{
			get { return _action; }
			set { _action = value; RaisePropertyChanged(() => Action); }
		}
	}
}

