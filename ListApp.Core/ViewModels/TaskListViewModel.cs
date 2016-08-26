using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MvvmCross.Core.ViewModels;
using ListApp;
using System.Windows.Input;
using System.Collections.ObjectModel;
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
			_listItems = new ObservableCollection<ItemTaskViewModel>(TaskСontainer.AllTask.Select(arg => new ItemTaskViewModel(arg.Description, arg.TaskDate, 0)));
			TaskСontainer.ListObject = this;
			base.Start();
		}

	}
}
