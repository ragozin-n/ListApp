using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace ListApp.Core
{
    public class SortViewModel : MvxViewModel
    {
        private List<string> _sortList;

        public List<string> SortList
        {
            get { return _sortList; }
            set
            {
                _sortList = value;
                RaisePropertyChanged(() => SortList);
            }
        }
    }
}