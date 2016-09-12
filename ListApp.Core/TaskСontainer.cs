using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ListApp.Core
{
	public class TaskСontainer
	{
		public static TaskListViewModel ListObject { get; set; }

		private static List<Task> allTask = new List<Task>();

		private static TypeSort _currentTypeSort = TypeSort.ByName;
		public static TypeSort CurrentTypeSort { get { return _currentTypeSort;}}

		private delegate void CurrentSort();
		private static CurrentSort _currentSort = SortByName;

		public static void ResetVisible()
		{
			_currentSort();
			int i = 0;
			ListObject.ListItems = new ObservableCollection<ItemTaskViewModel>(TaskСontainer.allTask.Select(arg => new ItemTaskViewModel(arg.Description, arg.TaskDate,arg.TaskTime, i++))); ;
		}

		public static void AddTask(Task task)
		{
			allTask.Add(task);
			ResetVisible();
		}
		/// <summary>
		/// Возвращает элемент по иднексу и удаляет его
		/// </summary>
		public static Task Seek(int index)
		{
			Task buffer = allTask[index];
			allTask.RemoveAt(index);
			return buffer;
		}

		public static void Remove(int index)
		{
			allTask.RemoveAt(index);
		}

		public static Task Get(int index)
		{
			return allTask[index];
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

		private static void SortByDate()
		{
			allTask =  allTask.OrderBy((arg) => DateTime.Parse(arg.TaskDate)).ThenBy((arg) => DateTime.Parse(arg.TaskTime)).ToList();
		}
		private static void SortByName()
		{
			allTask = allTask.OrderBy((arg) => arg.Description).ToList();
		}
		private static void SortByPriority()
		{
			allTask = allTask.OrderBy((arg) => arg.IsPriority).ToList();
		}
	}

	//28.08.16: Перечисления выделяют в отдельные классы.
	//11.09.16: Пусть пока здесь полежит
	public enum TypeSort
	{
		ByName,
		ByDate,
		ByPriority
	}
}

