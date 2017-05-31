using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Win32;
using MyCardio.Model;
using MyCardio.Utils;
using MyCardio.View;
using MyCardio.ViewModel.Commands;

namespace MyCardio.ViewModel
{
    public class UsersVM : ObservableObject
    {
        private static UsersVM _instance;
        public static UsersVM Instance => _instance ?? (_instance = new UsersVM());

        public ICommand SelectUserCommand => new SingleParameterCommand<ObservableUser>(SelectUser);
        public ICommand SelectUserAvatarCommand => new SingleParameterCommand<ObservableUser>(SelectUserAvatar);
        public ICommand CreateUserCommand => new NoParameterCommand(InitUserCreation);
        public ICommand DeleteUserCommand => new SingleParameterCommand<ObservableUser>(DeleteUser);

        private readonly List<User> _users;
        private readonly CustomObservableCollection<ObservableUser, User> _observableUsers;
        public IEnumerable<ObservableUser> ObservableUsers => _observableUsers;

        public UsersVM()
        {
            _users = Serializer.Deserialize<List<User>>(FileName) ?? new List<User>
            {
                new User("Krzys", @"C:\Users\filip\Pictures\John-Prideaux-headshot_picmonkeyed.jpg"),
                new User("SuperKrzys", null)
            };
            _observableUsers = new CustomObservableCollection<ObservableUser, User>(_users, u => new ObservableUser(u));
            Application.Current.Exit += CurrentOnExit;
        }

        private void CurrentOnExit(object sender, ExitEventArgs exitEventArgs)
        {
            Serializer.Serialize(_users, FileName);
        }

        public void SelectUser(ObservableUser observableUser)
        {
            PulsesOverviewVM.Instance.ObservableUser = observableUser;
            MainWindowVM.Navigate(typeof(PulsesOverview));
        }

        public void SelectUserAvatar(ObservableUser observableUser)
        {
//            var fileDialog = new OpenFileDialog();
//            var result = fileDialog.ShowDialog();
//
//            if (result == true)
//            {
//                var file = fileDialog.FileName;
//                observableUser.Image = file;
//            }
            ImagePicker.PickImage(observableUser, nameof(observableUser.Image));
        }

        private void InitUserCreation()
        {
            CreateUserVM.Instance.Init(typeof(SelectUser), NewUserCreated);
        }

        private void NewUserCreated(User user)
        {
            _observableUsers.Add(user);
        }

        private void DeleteUser(ObservableUser obj)
        {
            _observableUsers.Remove(obj);
            _users.Remove(obj.Source);
        }

        private const string FileName = "users.bin";
    }
}
