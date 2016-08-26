﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ListApp.Core.ViewModels;

using MvvmCross.Core.ViewModels;

namespace ListApp.Core
{
    public class ItemTaskViewModel : MvxViewModel
    {
        private string _nameTask;
        private DateTime _dateTask;
		private int _indexItem;

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

		public int IndexItem
		{
			get { return _indexItem; }
			set { _indexItem = value; }
		}

        public ItemTaskViewModel(string name, DateTime date, int indexItem)
        {
            this.NameTask = name;
            this.DateTask = date;
			this.IndexItem = indexItem;
        }

		private ICommand _editTask;

		public ICommand EditTask
		{
			get
			{
				_editTask = _editTask ?? new MvxCommand(Edit);
				return _editTask;
			}
		}
		private void Edit()
		{
			ShowViewModel<CreateTaskViewModel>(new { task = IndexItem });
		}
    }
}
