using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLib.model
{
    public class Vare
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Vare(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Vare():this(0, "", 0)
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
