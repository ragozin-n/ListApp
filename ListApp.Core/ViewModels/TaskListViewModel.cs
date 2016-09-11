using System;
using System.Linq;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ListApp.Core.ViewModels;

namespace ListApp.Core
{
	public class TaskListViewModel : MvxViewModel
	{
		private ObservableCollection<ItemTaskViewModel> _listItems;

		public ObservableCollection<ItemTaskViewModel> ListItems
		{
			get { return _listItems; }
			set
			{
				_listItems = value;
				RaisePropertyChanged(() => ListItems);
			}
		}

		public override void Start()
		{
			TaskСontainer.AddTask(new Task(false, true, "one", "10:02", new DateTime(10, 10, 10).ToString("D"), "10:00"));
			TaskСontainer.ListObject = this;
			TaskСontainer.ResetVisible();
			base.Start();
		}

		private ICommand _createTask;

		public ICommand CreateTask
		{
			get
			{
				_createTask = _createTask ?? new MvxCommand(Create);
				return _createTask;
			}
		}
		private void Create()
		{
			ShowViewModel<CreateTaskViewModel>(new { index = -1});
		}
	}
}
