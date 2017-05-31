using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using MyCardio.Model;
using MyCardio.ViewModel;

namespace MyCardio.View
{
    /// <summary>
    /// Interaction logic for PulsesOverview.xaml
    /// </summary>
    public partial class PulsesOverview : Page
    {
        public PulsesOverview()
        {
            DataContext = PulsesOverviewVM.Instance;
            InitializeComponent();
        }

        private void ClosingAddDialog(object sender, DialogClosingEventArgs eventArgs)
        {
            if (!int.TryParse(SystoleTextBox.Text, out int systole) ||
                !int.TryParse(DiastoleTextBox.Text, out int diastole)) return;

            PulsesOverviewVM.Instance.AddPuls(new Puls(systole, diastole, DatePicker.DisplayDate));
            RefreshGrid();
        }

        public void ClosingEditDialog(object sender, DialogClosingEventArgs eventArgs)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            var old = PulsesDataGrid.ItemsSource;
            PulsesDataGrid.ItemsSource = null;
            PulsesDataGrid.ItemsSource = old;
        }
    }
}