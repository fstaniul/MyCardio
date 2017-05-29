using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MyCardio.Model;
using MyCardio.Utils;

namespace MyCardio.ViewModel
{
    public class SelectUserVM : ObservableObject
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

        private readonly ObservableCollection<User> _users;
        public IEnumerable<User> Users => _users;

        public SelectUserVM()
        {
            _users = Serializer.Deserialize<ObservableCollection<User>>(FileName) ?? new ObservableCollection<User>();
            Application.Current.Exit += CurrentOnExit;
        }

        private void CurrentOnExit(object sender, ExitEventArgs exitEventArgs)
        {
            Serializer.Serialize(_users, FileName);
        }

        private const string FileName = "users.bin";
    }
}
