namespace ListApp.Core
{
	public class Task
	{
		//private bool _isAllDay;
		//private bool _isPriority;
		//private string _taskTime;
		//private string _recallForTime;
		//private string _taskDate;
		//private string _description;

		public Task() { }

		public Task(bool isPriority, bool isAllDay, string description, string taskTime, string taskDate, string recallForTime)
		{
			IsPriority = isPriority;
			IsAllDay = isAllDay;
			Description = description;
			TaskTime = taskTime;
			TaskDate = taskDate;
			RecallForTime = recallForTime;
		}

		public bool IsAllDay { get; set; }
		public bool IsPriority { get; set; }
		public string TaskTime { get; set; }
		public string TaskDate { get; set; }
		public string Description { get; set; }
		public string RecallForTime { get; set; }
	}
}

