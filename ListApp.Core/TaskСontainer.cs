using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ListApp.Core
{
	public class TaskСontainer
	{
		public TaskСontainer() { }
		public static TaskListViewModel ListObject;


		//private static List<Task> _allTask = new List<Task>();
		public static List<Task> AllTask { get; } = new List<Task>();

		//Это не совсем корректный код: достаточно будет ->
		//public static TypeSort CurrentTypeSort { get; set; } = TypeSort.ByName
		//Но слишком много логики на данном примере, так что не мог исправить
		private static TypeSort _currentTypeSort = TypeSort.ByName;
		public static TypeSort CurrentTypeSort { get { return _currentTypeSort;}}

		private delegate void CurrentSort();
		private static CurrentSort _currentSort = SortByDate;

		public static void ResetVisible()
		{
			_currentSort();
			ListObject.ListItems = new ObservableCollection<ItemTaskViewModel>(TaskСontainer.AllTask.Select(arg => new ItemTaskViewModel(arg.Description, arg.TaskDate, 0))); ;
		}

		public static void AddTask(Task task)
		{
			AllTask.Add(task);
			_currentSort();
		}
		/// <summary>
		/// Возвращает элемент по иднексу и удаляет его
		/// </summary>
		public static Task Seek(int index)
		{
			Task buffer = AllTask[index];
			AllTask.RemoveAt(index);
			return buffer;
		}

		public static void SetSort(TypeSort sort)
		{
			_currentTypeSort = sort;
			switch (sort)
			{
				case TypeSort.ByDate:
					{
						_currentSort = SortByDate;
						break;
					}
				case TypeSort.ByName:
					{
						_currentSort = SortByName;
						break;
					}
				case TypeSort.ByPriority:
					{
						_currentSort = SortByPriority;
						break;
					}
			}
		}

		//Достаточно будет одного метода Sort, который принимает TypeSort и свич. Также у enum есть каст к int, можно сделать более быстрый свич.
		private static void SortByDate()
		{
			AllTask.OrderBy((arg) => DateTime.Parse(arg.TaskDate)).ThenBy((arg) => DateTime.Parse(arg.TaskTime));
		}
		private static void SortByName()
		{
			AllTask.OrderBy((arg) => arg.Description);
		}
		private static void SortByPriority()
		{
			AllTask.OrderBy((arg) => arg.ISPriority);
		}
	}

	public enum TypeSort
	{
		ByName,
		ByDate,
		ByPriority
	}
}

