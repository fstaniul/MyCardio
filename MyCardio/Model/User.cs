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
        private static int _counter;

        public int Id { get; }
        public string Name { get; set; }
        public List<Puls> Pulses { get; }
        public string Image { get; set; }

        public User()
        {
        }

        public User(string name, string image)
        {
            Id = _counter++;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Pulses = new List<Puls>();
            Image = image;
        }

        public override bool Equals(object obj)
        {
            return obj is User user && user == this;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(User u1, User u2)
        {
            return u1?.Id == u2?.Id;
        }

        public static bool operator !=(User u1, User u2)
        {
            return !(u1 == u2);
        }

        public override string ToString()
        {
            return $"{Id}: {Name}, {Image}, {Pulses}";
        }
    }
}
