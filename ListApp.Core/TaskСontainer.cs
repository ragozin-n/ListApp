using System;
using System.Collections.Generic;

namespace ListApp.Core
{
	public class TaskСontainer
	{
		public TaskСontainer() { }
		private static List<Task> _allTask = new List<Task>();
		public static List<Task> AllTask { get { return _allTask; } }

		public static void AddTask(Task task)
		{
			_allTask.Add(task);
		}
	}
}

