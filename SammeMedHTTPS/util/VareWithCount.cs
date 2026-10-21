using SessionLib.model;
using System.Xml.Linq;

namespace SammeMedHTTPS.util
{
    public class VareWithCount : Vare
    {
        public int Count { get; set; }

        public VareWithCount(int id, string name, double price, int count) : base(id, name, price)
        {
            Count = count;
        }

        public VareWithCount() : this(0, "", 0, 0)
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Count)}={Count.ToString()}, {nameof(Id)}={Id.ToString()}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
