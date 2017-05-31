using System;

namespace MyCardio.Model
{
    [Serializable]
    public class Puls
    {
        public int Systole { get; set; }
        public int Diastole { get; set; }
        public DateTime DateTime { get; set; }

        public Puls(int systole, int diastole, DateTime dateTime)
        {
            Systole = systole;
            Diastole = diastole;
            DateTime = dateTime;
        }

        public override string ToString()
        {
            return $"{Systole} / {Diastole}";
        }
    }
}