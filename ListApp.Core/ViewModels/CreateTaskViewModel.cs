using System;
using MvvmCross.Core.ViewModels;

namespace ListApp.Core.ViewModels
{
	public class CreateTaskViewModel : MvxViewModel
	{
		private bool _isAllDay;
		private bool _isPriority;
		private string _taskTime;
		private string _recallForTime;
		private string _taskDate;
		private string _description;
		private IMvxCommand _cancel;
		private IMvxCommand _aplyied;

		public int? Index { get; set; } = null;

		public Task TaskObject { get; set; }
		//передается инт потому что 
		public void Init(int? task)
		{
			if (task == null)
			{
				var timeNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).ToString("g");
				TaskTime = timeNow.Remove(timeNow.Length - 3, 3);
				var timeOneHour = new TimeSpan(1, 0, 0).ToString("g");
				RecallForTime = timeOneHour.Remove(timeOneHour.Length - 3, 3);
				TaskDate = DateTime.Now.ToString("D");
				Description = "Новая задача";
			}
			else
			{
				TaskObject = TaskСontainer.AllTask[(int)task];
				IsAllDay = TaskObject.IsAllDay;
				IsPriority = TaskObject.ISPriority;
				TaskTime = TaskObject.TaskTime;
				TaskDate = TaskObject.TaskDate;
				RecallForTime = TaskObject.RecallForTime;
				Description = TaskObject.Description;
			}
		}

		public string Description
		{
			get { return _description; }
			set { _description = value; RaisePropertyChanged(() => Description); }
		}

		public string TaskDate
		{
			get { return _taskDate; }
			set { _taskDate = value; RaisePropertyChanged(() => TaskDate); }
		}

		public string RecallForTime
		{
			get { return _recallForTime; }
			set { _recallForTime = value; RaisePropertyChanged(() => RecallForTime); }
		}

		public bool IsPriority
		{
			get { return _isPriority; }
			set { _isPriority = value; RaisePropertyChanged(() => IsPriority); }
		}

		public bool IsAllDay
		{
			get { return _isAllDay; }
			set { _isAllDay = value; RaisePropertyChanged(() => IsAllDay); }
		}

		public string TaskTime
		{
			get { return _taskTime; }
			set { _taskTime = value; RaisePropertyChanged(() => TaskTime); }
		}


		public IMvxCommand CancelEvent
		{
			get
			{
				_cancel = _cancel ?? new MvxCommand(Cancel);
				return _cancel; 
			}
		}

		public IMvxCommand AplyiedEvent
		{
			get
			{
				_aplyied = _aplyied ?? new MvxCommand(Aplyied);
				return _aplyied;
			}
		}

		public void Cancel()
		{
			Close(this);
		}

		public void Aplyied()
		{
			if (TaskObject == null)
			{
				TaskСontainer.AddTask(new Task(IsPriority, IsAllDay, Description, TaskTime, TaskDate, RecallForTime));
			}
			else
			{
				TaskObject.ISPriority = IsPriority;
				TaskObject.IsAllDay = IsAllDay;
				TaskObject.Description = Description;
				TaskObject.TaskTime = TaskTime;
				TaskObject.TaskDate = TaskDate;
				TaskObject.RecallForTime = RecallForTime;
			}
			Close(this);
			TaskСontainer.ResetVisible();
		}
	}
}

