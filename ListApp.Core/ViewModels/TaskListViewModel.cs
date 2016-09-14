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
		private ObservableCollection<ItemLeftMenuViewModel> _leftItemList;

		public TaskListViewModel()
		{
			_leftItemList = new ObservableCollection<ItemLeftMenuViewModel>
			{
				new ItemLeftMenuViewModel("Новая задача", CreateTask),
				new ItemLeftMenuViewModel("Сортировка задач", CreateTask),
				new ItemLeftMenuViewModel("Настройки",new MvxCommand(GoSetting)),
				new ItemLeftMenuViewModel("Выход", new MvxCommand(Exit))
			};
		}
		public ObservableCollection<ItemLeftMenuViewModel> LeftItemList
		{
			get { return _leftItemList;}
			set { _leftItemList = value; RaisePropertyChanged(() => LeftItemList); }
		}
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
		private void Exit()
		{
			Close(this);
		}
		private void GoSetting()
		{
			ShowViewModel<SettingsViewModel>();
		}	
	}
}
