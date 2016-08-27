using System;
using Android.App;
using MvvmCross.Droid.Views;
using ListApp.Core.ViewModels;
using System.Linq;

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
			this.FindViewById(Resource.Id.SelectTimeButton).Click += SetTime;
			this.FindViewById(Resource.Id.RecallForButton).Click += SetRecallFor;
			this.FindViewById(Resource.Id.SelectDateButton).Click += SetDate;
		}

		//Create DataPicker
		private void SetDate(object sender, EventArgs e)
		{
			DateTime date = DateTime.Parse(ViewModel.TaskDate);
			date.AddMonths(-1);
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
			string[] buffer = ViewModel.TaskTime.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
			TimePickerDialog picker = new TimePickerDialog(this, SetTimeEvents, int.Parse(buffer[0]), int.Parse(buffer[1]), true);
			picker.Show();
		}
		private void SetTimeEvents(object sender, TimePickerDialog.TimeSetEventArgs e)
		{
			var time = new TimeSpan(e.HourOfDay, e.Minute, 0).ToString("g");
			this.ViewModel.TaskTime = time.Remove(time.Length - 3, 3);
		}

		private void SetRecallFor(object sender, EventArgs e)
		{
			//a hour
			string[] buffer = ViewModel.RecallForTime.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
			Dialog picker = new TimePickerDialog(this, SetTimeRecallForEvents, int.Parse(buffer[0]), int.Parse(buffer[1]), true);
			//Title too
			picker.Show();
		}

		private void SetTimeRecallForEvents(object sender, TimePickerDialog.TimeSetEventArgs e)
		{
			var time = new TimeSpan(e.HourOfDay, e.Minute, 0).ToString("g");
			this.ViewModel.RecallForTime = time.Remove(time.Length - 3, 3);
		}
	}
}

