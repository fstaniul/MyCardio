using System;
using MyCardio.ViewModel;

namespace MyCardio.Model
{
    public class ObservablePuls : ObservableObject, ISourceContainer<Puls>
    {
        public Puls Source { get; }

        public int Systole
        {
            get => Source.Systole;
            set
            {
                Source.Systole = value;
                RaisePropertyChangedEvent(nameof(Systole));
            } 
        }

        public int Diastole
        {
            get => Source.Diastole;
            set
            {
                Source.Diastole = value;
                RaisePropertyChangedEvent(nameof(Diastole));
            } 
        }

        public DateTime DateTime
        {
            get => Source.DateTime;
            set
            {
                Source.DateTime = value;
                RaisePropertyChangedEvent(nameof(DateTime));
            }
        }

        public ObservablePuls(Puls puls)
        {
            Source = puls ?? throw new ArgumentNullException(nameof(puls));
        }
    }
}