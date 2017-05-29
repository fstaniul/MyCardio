using System;

namespace MyCardio.Model
{
    [Serializable]
    public class Puls
    {
        public int Systole { get; set; }
        public int Diastole { get; set; }

        public Puls(int systole, int diastole)
        {
            Systole = systole;
            Diastole = diastole;
        }
    }
}