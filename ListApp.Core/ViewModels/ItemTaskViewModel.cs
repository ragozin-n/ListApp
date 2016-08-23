using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MvvmCross.Core.ViewModels;

namespace ListApp.Core
{
    public class ItemTaskViewModel:MvxViewModel
    {
        private string _nameTask;
        private DateTime _dateTask;

        public string NameTask
        {
            get { return _nameTask; }
            set { _nameTask = value; }
        }
        public DateTime DateTask
        {
            get { return _dateTask; }
            set { _dateTask = value; }
        }

        public ItemTaskViewModel(string name, DateTime date)
        {
            this.NameTask = name;
            this.DateTask = date;
        }
    }
}
