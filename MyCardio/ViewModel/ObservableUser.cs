using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using MaterialDesignThemes.Wpf.Transitions;
using MyCardio.ViewModel;

namespace MyCardio.Model
{
    public class ObservableUser : ObservableObject
    {
        private User _source;

        public string Name
        {
            get => _source.Name;
            set
            {
                _source.Name = value;
                RaisePropertyChangedEvent(nameof(Name));
            }
        }

        public string Image
        {
            get => _source.Image;
            set
            {
                _source.Image = value;
                RaisePropertyChangedEvent(nameof(Image));
            }
        }

        public CustomObservableCollection<ObservablePuls, Puls> Pulses
        {
            get;
        }

        public ObservableUser(User source)
        {
            this._source = source ?? throw new ArgumentNullException(nameof(source));
            Pulses = new CustomObservableCollection<ObservablePuls, Puls>(source.Pulses, p => new ObservablePuls(p));
        }
    }

    public class CustomObservableCollection<T, S> : ObservableCollection<T>
    {
        private readonly List<S> _source;
        private readonly Func<S, T> _sourceMapper;

        public CustomObservableCollection(List<S> source, Func<S, T> sourceMapper)
        {
            _source = source;
            _sourceMapper = sourceMapper;
            foreach (var s in _source)
            {
                base.Add(sourceMapper.Invoke(s));
            }
        }

        public void Add(S obj)
        {
            _source.Add(obj);
            base.Add(_sourceMapper.Invoke(obj));
        }
    }
}
