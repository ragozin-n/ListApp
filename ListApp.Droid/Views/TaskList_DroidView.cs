using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MvvmCross.Droid.Views;
using ListApp.Core;

namespace ListApp.Views
{
    [Activity(Theme = "@android:style/Theme.Material.Light", Label = "@string/app_name")]
    public class TaskList_DroidView : MvxActivity
    {
        private ListView taskList;

        public new TaskListViewModel ViewModel
        {
            get
            {
                return (TaskListViewModel)base.ViewModel;
            }
            set
            {
                base.ViewModel = value;
            }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.TaskList);
            TaskListViewModel el = new TaskListViewModel();
            el.AddItems();
            taskList = FindViewById<ListView>(Resource.Id.TaskList);
            taskList.Adapter = new TaskAdapter(el.listItems);
            taskList.ItemClick += taskList_ItemClick;
        }

        void taskList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            
        }



        public class TaskAdapter : BaseAdapter<ItemTaskViewModel>
        {
            protected IList<ItemTaskViewModel> _tasks;

            public TaskAdapter(IList<ItemTaskViewModel> tasks)
            {
                _tasks = tasks;
            }

            public override ItemTaskViewModel this[int position]
            {
                get
                {
                    return _tasks[position];
                }
            }

            public override int Count
            {
                get
                {
                    return _tasks.Count;
                }
            }

            public override long GetItemId(int position)
            {
                return position;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.TemplateItemTaskView, parent, false);

                var name = view.FindViewById<TextView>(Resource.Id.nameTask);
                var date = view.FindViewById<TextView>(Resource.Id.dateTask);
                var condition = view.FindViewById<ImageView>(Resource.Id.conditionTask);

                name.Text = _tasks[position].NameTask;
                date.Text = _tasks[position].DateTask.ToString("D");
                condition.SetImageResource (GetImage ("default"));
                return view;
            }

            protected int GetImage(string name)
            {
                switch (name)
                {
                    case "default":
                        return Resource.Drawable.status;
                    case "done":
                        return Resource.Drawable.status_done_button;
                    case "important":
                        return Resource.Drawable.status_important;
                }
                return 0;
            }

            //public virtual void Remove(ItemTaskViewModel item)
            //{
            //    _tasks.Remove(item);
            //}

            //public virtual void Remove(IEnumerable<ItemTaskViewModel> items)
            //{
            //    foreach (var item in items)
            //    {
            //        _tasks.Remove(item);
            //    }
            //}

            //public virtual ItemTaskViewModel GetRawItem(int position)
            //{
            //    return _tasks[position];
            //}

        }
    }

}