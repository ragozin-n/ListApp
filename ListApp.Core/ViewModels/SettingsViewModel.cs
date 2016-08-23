using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace ListApp.Core
{
    public class SettingsViewModel : MvxViewModel
    {
        //просто подставить данные с jsona или если там уже есть полное имя то замечательно
        //TODO: cообразить как сразу пихать в круг картинку ссылкой
        public SettingsViewModel()
        {
            IsSyncEnabled = true;
            IsPushEnabled = true;
            FirstName = "Дед";
            LastName = "Егор";
            EmailAddress = "getitfrom@google.com";
            FullName = FirstName + " " + LastName;
            //PhotoUrl = "https://pp.vk.me/c631520/v631520910/3980f/ZIsBW-xlt34.jpg"
        }

        #region Properties

        private bool _isPushEnabled;
        public bool IsPushEnabled
        {
            get { return _isPushEnabled; }
            set
            {
                _isPushEnabled = value;
                RaisePropertyChanged(() => IsPushEnabled);
            }
        }

        private bool _isSyncEnabled;
        public bool IsSyncEnabled
        {
            get { return _isSyncEnabled; }
            set
            {
                _isSyncEnabled = value;
                RaisePropertyChanged(() => IsSyncEnabled);
            }
        }

        private string _emailAddress;
        public string EmailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; RaisePropertyChanged(() => EmailAddress); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged(() => FirstName);
            }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; RaisePropertyChanged(() => FullName); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged(() => LastName);
            }
        }

        private string _photoUrl;
        public string PhotoUrl
        {
            get { return _photoUrl; }
            set { _photoUrl = value; RaisePropertyChanged(() => PhotoUrl); }
        }

        #endregion

        #region Commands

        private MvxCommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                _logoutCommand = _logoutCommand ?? new MvxCommand(DoLogoutCommand);
                return _logoutCommand;
            }
        }

        private void DoLogoutCommand()
        {
            //
        }

        private MvxCommand _returnCommand; // возврат в меню
        public ICommand ReturnCommand
        {
            get
            {
                _returnCommand = _returnCommand ?? new MvxCommand(DoReturnCommand);
                return _returnCommand;
            }
        }

        private void DoReturnCommand()
        {
            //
        }

        #endregion

    }
}