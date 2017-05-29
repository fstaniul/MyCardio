﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf.Transitions;
using MyCardio.Model;
using MyCardio.Utils;
using MyCardio.ViewModel.Commands;

namespace MyCardio.ViewModel
{
    public class UsersVM : ObservableObject
    {
        private User _currentUser;

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser == value) return;
                _currentUser = value;
                RaisePropertyChangedEvent(nameof(CurrentUser));
            }
        }

        public ICommand SelectUserCommand => new SingleParameterCommand<User>(SelectUser);

        private readonly ObservableCollection<User> _users;
        public IEnumerable<User> Users => _users;

        public UsersVM()
        {
            _users = Serializer.Deserialize<ObservableCollection<User>>(FileName) ?? new ObservableCollection<User>{new User("Kuba", @"C:\Users\filip\Pictures\John-Prideaux-headshot_picmonkeyed.jpg"), new User("Krzyś", null) };
            Application.Current.Exit += CurrentOnExit;
        }

        private void CurrentOnExit(object sender, ExitEventArgs exitEventArgs)
        {
            Serializer.Serialize(_users, FileName);
        }

        public void SelectUser(User user)
        {
            Debug.WriteLine(user);
        }

        private const string FileName = "users.bin";
    }
}