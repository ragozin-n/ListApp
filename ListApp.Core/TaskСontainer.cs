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

		//28.08.16: Ваще непонятно зачем
		//private static List<Task> _allTask = new List<Task>();
		public static List<Task> AllTask { get; } = new List<Task>();

		//28.08.16: Тоже самое, что и выше. Дефолтное значение задается при инициализации. Менять не стал, так как логики много внутри, лень разбираться.
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

		//28.08.16: DRY - достаточно будет одного метода Sort, который принимает List<Task> и TypeSort и в свиче подставляет. Кстати, enum можно кастить к int.
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
			AllTask.OrderBy((arg) => arg.IsPriority);
		}
	}

	//28.08.16: Перечисления выделяют в отдельные классы.
	public enum TypeSort
	{
		ByName,
		ByDate,
		ByPriority
	}
}

