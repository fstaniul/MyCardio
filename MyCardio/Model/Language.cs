using System;
using System.Drawing;

namespace MyCardio.Model
{
    public class Language
    {
        public Bitmap Icon { get; }
        public string Culture { get; }

        public Language(string culture, Bitmap icon)
        {
            Culture = culture ?? throw new ArgumentNullException(nameof(culture));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
        }
    }
}