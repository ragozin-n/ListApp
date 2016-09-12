using System;
using Android.App;
using MvvmCross.Droid.Views;
using ListApp.Core.ViewModels;
using Android.Widget;
using Android.Database;
using Android.Views;
using Java.Lang;

namespace ListApp
{
	[Activity(Theme = "@android:style/Theme.Material.Light.NoActionBar")]
	public class CreateTaskView : MvxActivity
	{
		public new CreateTaskViewModel ViewModel
		{
			get { return (CreateTaskViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}
		protected override void OnViewModelSet()
		{
			SetContentView(Resource.Layout.CreateTask);
			FindViewById(Resource.Id.SelectTimeButton).Click += SetTime;

			//Так как спинер не хотел корректно работать через data binding, то прописал все в ручную
			Spinner spinner = FindViewById<Android.Widget.Spinner>(Resource.Id.RecallForButton);
			spinner.ItemSelected +=  new EventHandler<AdapterView.ItemSelectedEventArgs>(ClickSprinner);
			spinner.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, ViewModel.ItemsPushTime);
			int index = (ViewModel.ItemsPushTime.IndexOf(ViewModel.SelectedItemPushTime));
			spinner.SetSelection(index);

			FindViewById(Resource.Id.SelectDateButton).Click += SetDate;
			if (ViewModel.TaskObject != null)
				FindViewById<TextView>(Resource.Id.TitleCreateTask).Text = "Редактировать задачу";
			FindViewById(Resource.Id.DescriptionTaskTextView).Click += ClickTitle;
			FindViewById(Resource.Id.IsAllDayRowSwith).Click += ClickSwitchAllDay;
			ClickSwitchAllDay(new object(), new EventArgs());
		}

		private void ClickSprinner(object sender, EventArgs e)
		{
			var spinner = sender as Spinner;
			ViewModel.SelectedItemPushTime = spinner.SelectedItem.ToString();
		}

		//Обработка свича весь день
		private void ClickSwitchAllDay(object sender, EventArgs e)
		{
			bool current = FindViewById<Switch>(Resource.Id.IsAllDayRowSwith).Checked;
			FindViewById(Resource.Id.SelectTimeButton).Clickable = !current;
			FindViewById(Resource.Id.RecallForButton).Clickable = !current;
			if (current)
			{
				FindViewById(Resource.Id.RecallFor).SetBackgroundColor(Android.Graphics.Color.Silver);
				FindViewById(Resource.Id.SelectTime).SetBackgroundColor(Android.Graphics.Color.Silver);
			}
			else
			{
				FindViewById(Resource.Id.RecallFor).SetBackgroundColor(Android.Graphics.Color.White);
				FindViewById(Resource.Id.SelectTime).SetBackgroundColor(Android.Graphics.Color.White);
				if (string.IsNullOrEmpty(ViewModel.TaskTime))
					ViewModel.TaskTime = DateTime.Now.ToString("t");
			}
		}

		//Стираем название при первом клике на описание задачи
		private void ClickTitle(object sender, EventArgs e)
		{
			if (!isExistFirstClickTitle)
			{
				FindViewById<TextView>(Resource.Id.DescriptionTaskTextView).Text = "";
				isExistFirstClickTitle = true;
			}
		}
		private bool isExistFirstClickTitle = false;

		//Create DataPicker
		private void SetDate(object sender, EventArgs e)
		{
			DateTime date = DateTime.Parse(ViewModel.TaskDate);
			Dialog picker = new DatePickerDialog(this, SetDateEvent, date.Year, date.Month, date.Day);
			picker.Show();
		}
		private void SetDateEvent(object sender, DatePickerDialog.DateSetEventArgs e)
		{
			ViewModel.TaskDate = e.Date.ToString("D");
		}

		//Create timePicker
		//Установить title
		private void SetTime(object sender, EventArgs e)
		{
			string[] buffer = new string[2];
			if (string.IsNullOrEmpty(ViewModel.TaskTime))
			{
				buffer[0] = DateTime.Now.Hour.ToString();
				buffer[1] = DateTime.Now.Minute.ToString();
			}
			else
			{
				buffer = ViewModel.TaskTime.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
			}
			TimePickerDialog picker = new TimePickerDialog(this, SetTimeEvents, int.Parse(buffer[0]), int.Parse(buffer[1]), true);
			picker.Show();
		}
		private void SetTimeEvents(object sender, TimePickerDialog.TimeSetEventArgs e)
		{
			var time = new TimeSpan(e.HourOfDay, e.Minute, 0);
			this.ViewModel.TaskTime = time.ToString("g");
		}
	}
}

