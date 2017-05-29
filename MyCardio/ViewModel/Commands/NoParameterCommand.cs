using System;
using System.Windows.Input;

namespace MyCardio.ViewModel.Commands
{
    public class NoParameterCommand : ICommand
    {
        private readonly Action _action;

        public NoParameterCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
    }
}
