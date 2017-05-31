using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using MyCardio.Model;
using MyCardio.View;
using MyCardio.ViewModel.Commands;

namespace MyCardio.ViewModel
{
    public delegate void UserCreated(User user);

    public class CreateUserVM : ObservableObject
    {
        private static CreateUserVM _instance;
        public static CreateUserVM Instance => _instance ?? (_instance = new CreateUserVM());

        private Type _previousPageType;
        private string _name;
        private string _image;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChangedEvent(nameof(Name));
            }
        }

        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                RaisePropertyChangedEvent(nameof(Image));
            }
        }

        private UserCreated _createdDelegate;

        public ICommand CancelCommand => new NoParameterCommand(Finish);
        public ICommand AcceptCommand => new NoParameterCommand(Accept);
        public ICommand SelectAvatarCommand => new NoParameterCommand(SelectAvatar);

        private void SelectAvatar()
        {
            var fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();

            if (result == true)
            {
                var file = fileDialog.FileName;
                Image = file;
            }
        }

        public void Init(Type prevoiusPage, UserCreated userCreatedDelegate)
        {
            _createdDelegate = userCreatedDelegate;
            MainWindowVM.Navigate(typeof(CreateUser));
            _previousPageType = prevoiusPage;
            Name = "";
            Image = null;
        }

        private void Accept()
        {
            _createdDelegate?.Invoke(new User(Name, Image));
            Finish();
        }

        private void Finish()
        {
            MainWindowVM.Navigate(_previousPageType);
        }
    }
}