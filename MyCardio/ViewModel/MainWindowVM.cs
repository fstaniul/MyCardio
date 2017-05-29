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
            
        }

        private MainWindow _mainWindow;

        private Dictionary<Type, Page> Pages { get; }

        private MainWindowVM(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            Pages = new Dictionary<Type, Page>
            {
                
            };
        }

        public void Navigate(Type type)
        {
            if (Pages[type] == null) throw new ArgumentException("Type of page not found!", nameof(type));
            _mainWindow.Frame.Navigate(Pages[type]);
        }
    }
}
