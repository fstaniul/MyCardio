using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyCardio.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public List<Puls> Pulses { get; }

        public User(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
