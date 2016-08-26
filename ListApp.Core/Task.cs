using System;
using System.Xml.Serialization;
using System.Xml;

namespace ListApp.Core
{
	public class Task
	{
		private bool _isAllDay;
		private bool _isPriority;
		private string _taskTime;
		private string _recallForTime;
		private string _taskDate;
		private string _description;

		public Task() { }

		public Task(bool isPriority, bool isAllDay, string description, string taskTime, string taskDate, string recallForTime)
		{
			_isPriority = isPriority;
			_isAllDay = isAllDay;
			_description = description;
			_taskTime = taskTime;
			_taskDate = taskDate;
			_recallForTime = recallForTime;
		}

		public bool IsAllDay { get { return _isAllDay; }}
		public bool ISPriority { get { return _isAllDay; }}
		public string TaskTime { get { return _taskTime; } }
		public string TaskDate { get { return _taskDate; } }
		public string Description { get { return _description; } }
		public string RecallForTime { get { return _recallForTime; } }
	}
}

