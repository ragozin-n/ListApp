using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MvvmCross.Core.ViewModels;



namespace ListApp.Core
{
    public class TaskListViewModel : MvxViewModel
    {
        public List<ItemTaskViewModel> listItems = new List<ItemTaskViewModel>();

        public void AddItems()
        {
            listItems.Add(new ItemTaskViewModel("Доделать", new DateTime(2016, 08, 22)));
            listItems.Add(new ItemTaskViewModel("Эту", new DateTime(2016, 08, 23)));
            listItems.Add(new ItemTaskViewModel("Ебучую", new DateTime(2016, 08, 24)));
            listItems.Add(new ItemTaskViewModel("Переделанную", new DateTime(2016, 08, 25)));
            listItems.Add(new ItemTaskViewModel("Ура", new DateTime(2016, 08, 26)));
            listItems.Add(new ItemTaskViewModel("Я", new DateTime(2016, 08, 26)));
            listItems.Add(new ItemTaskViewModel("Сделяль!", new DateTime(2016, 08, 26)));
        }
    }
}
