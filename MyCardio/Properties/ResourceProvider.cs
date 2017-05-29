using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MyCardio.Properties
{
    public class ResourceProvider
    {
        private static ObjectDataProvider _provider;

        public static ObjectDataProvider Provider =>
            _provider ?? (_provider = (ObjectDataProvider) Application.Current.FindResource("Resources"));

        public Resources GetResources()
        {
            return new Resources();
        }

        public static void ChangeCulture(CultureInfo culture)
        {
            Resources.Culture = culture;
            _provider.Refresh();
        }
    }
}