using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCardio.Model;
using MyCardio.View;
using MyCardio.ViewModel.Commands;

namespace MyCardio.ViewModel
{
    public class PulsesOverviewVM : ObservableObject
    {
        private static PulsesOverviewVM _instance;
        public static PulsesOverviewVM Instance => _instance ?? (_instance = new PulsesOverviewVM());

        private ObservableUser _observableUser;
        
        public ObservableUser ObservableUser
        {
            get => _observableUser;
            set
            {
                _observableUser = value;
                RaisePropertyChangedEvent(nameof(ObservableUser));
            }
        }

        public ICommand SelectUsersCommand => new NoParameterCommand(SelectUsers);
        public ICommand DeleteRowInDataGrid => new SingleParameterCommand<ObservablePuls>(_deleteRowInDataGrid);

        public void AddPuls(Puls puls)
        {
            ObservableUser.Pulses.Add(puls);
        }

        private void SelectUsers()
        {
            MainWindowVM.Navigate(typeof(SelectUser));
        }

        private void _deleteRowInDataGrid(ObservablePuls puls)
        {
            ObservableUser.Pulses.Remove(puls);
        }
    }
}
