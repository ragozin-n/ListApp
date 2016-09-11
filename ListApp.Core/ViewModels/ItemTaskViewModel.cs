using System.Windows.Input;
using ListApp.Core.ViewModels;

using MvvmCross.Core.ViewModels;

namespace ListApp.Core
{
    public class ItemTaskViewModel : MvxViewModel
    {
        private string _nameTask;
		private string _dateTask;
		private string _timeTask;
		private int indexItem;

        public string NameTask
        {
            get { return _nameTask; }
			set { _nameTask = value; RaisePropertyChanged(() => NameTask);}
        }
		public string DateTask
        {
            get { return _dateTask; }
			set { _dateTask = value; RaisePropertyChanged(() => DateTask);}
        }
		public string TimeTask
		{
			get { return _timeTask; }
			set { _timeTask = value; RaisePropertyChanged(() => TimeTask); }
		}
		public ItemTaskViewModel(string name, string date, string time, int indexItem)
        {
            NameTask = name;
            DateTask = date;
			TimeTask = time;
			this.indexItem = indexItem;
        }

		private ICommand _editTask;

		public ICommand EditTask
		{
			get
			{
				_editTask = _editTask ?? new MvxCommand(Edit);
				return _editTask;
			}
		}
		private void Edit()
		{
			ShowViewModel<CreateTaskViewModel>(new { index = indexItem });
		}
    }
}
