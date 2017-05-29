using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyCardio.ViewModel.Commands
{
    public class SingleParameterCommand <T> : ICommand
    {
        private readonly Action<T> _action;

        public SingleParameterCommand(Action<T> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action((T) parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
