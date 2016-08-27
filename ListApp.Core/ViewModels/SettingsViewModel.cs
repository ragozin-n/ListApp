<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 5e001cf... Merge remote-tracking branch 'origin/master'
﻿using System.Windows.Input;
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
            EmailAddress = "getitfrom@google.com";
            FullName = "Тетя Паша";
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

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; RaisePropertyChanged(() => FullName); }
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
<<<<<<< HEAD
=======
=======
>>>>>>> origin/master
﻿using System.Windows.Input;
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
            EmailAddress = "getitfrom@google.com";
            FullName = "Тетя Паша";
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

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; RaisePropertyChanged(() => FullName); }
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
<<<<<<< HEAD
>>>>>>> origin/master
=======
>>>>>>> origin/master
=======
>>>>>>> parent of 5e001cf... Merge remote-tracking branch 'origin/master'
}