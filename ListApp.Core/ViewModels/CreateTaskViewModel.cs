using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace ListApp.Core.ViewModels
{
	public class CreateTaskViewModel : MvxViewModel
	{
		private bool _isAllDay;
		private bool _isPriority;
		private string _taskTime;
		private string _taskDate;
		private string _description;
		private IMvxCommand _cancel;
		private IMvxCommand _aplyied;
		//13.09.16: DataBinding для spinner не работает, пришлось сделать по кривому, хоть что-то
		//Дефолтные значение от которых будем плясать, почти не расширяется
		private List<string> _itemsPushTime = new List<string>()
		{
			"5 минут",
			"10 минут",
			"30 минут",
			"1 час",
			"12 часов",
			"1 сутки"
		};
		//Выбранный текущий элемент в списке - в пользовательском формате
		public string SelectedItemPushTime { get; set; }

		public List<string> ItemsPushTime
		{
			get { return _itemsPushTime; }
			set { _itemsPushTime = value; RaisePropertyChanged(() => "ItemsPushTime"); }
		}

		public Task TaskObject { get; set; }

		public void Init(int index)
		{
			if (index == -1)
			{
				var timeNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).ToString("g");
				TaskTime = timeNow.Remove(timeNow.Length - 3, 3);
				var timeOneHour = new TimeSpan(1, 0, 0).ToString("g");
				SelectedItemPushTime = ItemsPushTime[0];
				TaskDate = DateTime.Now.ToString("D");
				Description = "Новая задача";
				TaskObject = null;
			}
			else
			{
				TaskObject = TaskСontainer.Get(index);
				IsAllDay = TaskObject.IsAllDay;
				IsPriority = TaskObject.IsPriority;
				TaskTime = TaskObject.TaskTime;
				TaskDate = TaskObject.TaskDate;
				SelectedItemPushTime = GetNamePushTime(DateTime.Parse(TaskObject.RecallForTime), TimeSpan.Parse(TaskObject.TaskTime));
				Description = TaskObject.Description;
			}
		}

		public string Description
		{
			get { return _description; }
			set { _description = value; RaisePropertyChanged(() => Description); }
		}
		//В формате "D" из DateTime
		public string TaskDate
		{
			get { return _taskDate; }
			set { _taskDate = value; RaisePropertyChanged(() => TaskDate); }
		}

		public bool IsPriority
		{
			get { return _isPriority; }
			set { _isPriority = value; RaisePropertyChanged(() => IsPriority); }
		}
		//Назначаем задачу без особого времени выполнения, просто на дату
		public bool IsAllDay
		{
			get { return _isAllDay; }
			set { _isAllDay = value; RaisePropertyChanged(() => IsAllDay); }
		}
		//Время выполнения задачи в "t" из TaskTime
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

		private void Cancel()
		{
			Close(this);
		}

		private void Aplyied()
		{
			string recallForTime = GetPushTime(SelectedItemPushTime).ToString("g");
			if (TaskObject == null)
			{
				TaskСontainer.AddTask(new Task(IsPriority, IsAllDay, Description, TaskTime, TaskDate, recallForTime));
			}
			else
			{
				TaskObject.IsPriority = IsPriority;
				TaskObject.IsAllDay = IsAllDay;
				TaskObject.Description = Description;
				TaskObject.TaskTime = TaskTime;
				TaskObject.TaskDate = TaskDate;
				TaskObject.RecallForTime = recallForTime;
			}
			Close(this);
			TaskСontainer.ResetVisible();
		}
		//По дате выполнения, дате пуш уведомления, времени выполнения высчитываем промежуток 
		//TimeSpan больше суток не принимает, потому данная функция корректно будет работать
		//Только для величин строго меньше 24 часов 
		private string GetNamePushTime(DateTime pushDate, TimeSpan taskTime)
		{
			TimeSpan pushTime = new TimeSpan(pushDate.Hour, pushDate.Minute, pushDate.Second);
			TimeSpan time = new TimeSpan(pushDate.Hour, pushDate.Minute, pushDate.Second) - taskTime;
			if (pushTime.CompareTo(taskTime) < 0)
				time  = time.Add(new TimeSpan(24, 0, 0));
			if (pushTime.CompareTo(taskTime) == 0)
				return ItemsPushTime[5];
			switch (time.Minutes + 60 * time.Hours)
			{
				case 5: return ItemsPushTime[0];
				case 10: return ItemsPushTime[1];
				case 30: return ItemsPushTime[2];
				case 60: return ItemsPushTime[3];
				case 720: return ItemsPushTime[4];
				case 1440: return ItemsPushTime[5];
				default: return "";
			}
		}
		//Высчитывает время и даты выдачи пуш уведомления
		private DateTime GetPushTime(string str)
		{
			TimeSpan time;
			switch (str)
			{
				case "5 минут":
					{
						time = new TimeSpan(0, 5, 0);
						break;
					}
				case "10 минут":
					{
						time = new TimeSpan(0, 10, 0);
						break;
					}
				case "30 минут":
					{
						time = new TimeSpan(0, 30, 0);
						break;
					}
				case "1 час":
					{
						time = new TimeSpan(1, 0, 0);
						break;
					}
				case "12 часов":
					{
						time = new TimeSpan(12, 0, 0);
						break;
					}
				case "1 сутки":
					{
						time = new TimeSpan(24, 0, 0);
						break;
					}
			}
			DateTime date = DateTime.Parse(TaskDate);
			TimeSpan timeTask = TimeSpan.Parse(TaskTime);
			return date.Add(timeTask + time);
		}
	}
}

