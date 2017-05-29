using System;
using MyCardio.ViewModel;

namespace MyCardio.Model
{
    public class ObservablePuls : ObservableObject
    {
        private Puls _puls;

        public int Systole
        {
            get => _puls.Systole;
            set
            {
                _puls.Systole = value;
                RaisePropertyChangedEvent(nameof(Systole));
            } 
        }

        public int Diastole
        {
            get => _puls.Diastole;
            set
            {
                _puls.Diastole = value;
                RaisePropertyChangedEvent(nameof(Diastole));
            } 
        }

        public ObservablePuls(Puls puls)
        {
            _puls = puls ?? throw new ArgumentNullException(nameof(puls));
        }
    }
}