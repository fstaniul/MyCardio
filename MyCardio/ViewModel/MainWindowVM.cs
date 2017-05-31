using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using MaterialDesignThemes.Wpf;
using MyCardio.Model;
using MyCardio.Properties;
using MyCardio.View;
using MyCardio.ViewModel.Commands;

namespace MyCardio.ViewModel
{
    public class MainWindowVM : ObservableObject
    {
        private static MainWindowVM _instance;
        public static MainWindowVM Instance => _instance;

        public static void Create(MainWindow mainWindow)
        {
            _instance = new MainWindowVM(mainWindow);
        }

        private readonly MainWindow _mainWindow;

        private Dictionary<Type, Page> Pages { get; }

        private readonly ObservableCollection<Language> _languages;

        public IEnumerable<Language> Languages => _languages;

        public ICommand SelectLanguage => new SingleParameterCommand<Language>(_selectLanguage);

        private MainWindowVM(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            Pages = new Dictionary<Type, Page>
            {
                {typeof(SelectUser), new SelectUser()},
                {typeof(CreateUser), new CreateUser()},
                {typeof(PulsesOverview), new PulsesOverview()}
            };

            _languages = new ObservableCollection<Language>
            {
                {new Language("en-EN", Images.EnglishFlag) },
                {new Language("pl-PL", Images.PolishFlag) }
            };
        }

        public static void Navigate(Type type)
        {
            try
            {
                if (_instance.Pages[type] == null) throw new ArgumentException("Type of page not found!", nameof(type));
                _instance?._mainWindow.Frame.Navigate(_instance.Pages[type]);
            }
            catch (KeyNotFoundException)
            {
                //Ignore this, just do nothing!
            }
        }

        private void _selectLanguage(Language language)
        {
            ResourceProvider.ChangeCulture(new CultureInfo(language.Culture));
        }
    }
}