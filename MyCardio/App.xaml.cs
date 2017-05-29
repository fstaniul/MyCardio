using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MyCardio
{
    public delegate void DoAtExit();

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public event DoAtExit ExitEvent;

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            ExitEvent?.Invoke();
        }
    }
}
