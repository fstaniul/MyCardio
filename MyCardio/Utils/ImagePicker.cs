using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MyCardio.Utils
{
    public class ImagePicker
    {
        public static void PickImage(object target, string propertyName)
        {
            // Configure open file dialog box 
            var dlg = new OpenFileDialog
            {
                Filter = "All Files (*.*)|*.*"
            };

            var codecs = ImageCodecInfo.GetImageEncoders();
            const string sep = "|";

            foreach (var c in codecs)
            {
                var codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                dlg.Filter = string.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
            }

            dlg.DefaultExt = ".png"; // Default file extension 

            // Show open file dialog box 
            var result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                target.GetType().GetProperty(propertyName)?.SetValue(target, dlg.FileName);
            }
        }
    }
}
