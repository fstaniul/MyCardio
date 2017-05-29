using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MyCardio.View;

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

        private MainWindow _mainWindow;

        private Dictionary<Type, Page> Pages { get; }

        private MainWindowVM(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            Pages = new Dictionary<Type, Page>
            {
                {typeof(SelectUser), new SelectUser()}
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
    }
}