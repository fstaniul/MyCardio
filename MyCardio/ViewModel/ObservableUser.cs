using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.AccessControl;
using System.Windows.Markup;
using MaterialDesignThemes.Wpf.Transitions;
using MyCardio.ViewModel;

namespace MyCardio.Model
{
    public class ObservableUser : ObservableObject, ISourceContainer<User>
    {
        public User Source { get; }

        public string Name
        {
            get => Source.Name;
            set
            {
                Source.Name = value;
                RaisePropertyChangedEvent(nameof(Name));
            }
        }

        public string Image
        {
            get => Source.Image;
            set
            {
                Source.Image = value;
                RaisePropertyChangedEvent(nameof(Image));
            }
        }

        public CustomObservableCollection<ObservablePuls, Puls> Pulses
        {
            get;
        }

        public ObservableUser(User source)
        {
            this.Source = source ?? throw new ArgumentNullException(nameof(source));
            Pulses = new CustomObservableCollection<ObservablePuls, Puls>(source.Pulses, p => new ObservablePuls(p));
        }
    }

    public interface ISourceContainer <S>
    {
        S Source { get; }
    }

    public class CustomObservableCollection<T, S> : ObservableCollection<T> where T : ISourceContainer<S>
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

        public new void Remove(T obj)
        {
            _source.Remove(obj.Source);
            base.Remove(obj);
        }
    }
}
