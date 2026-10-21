using SessionLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionLib.repository
{
    public class VarerRepo : IVarerRepo
    {
        // instans felter
        private List<Vare> _varer;

        // constructor
        public VarerRepo()
        {
            _varer = new List<Vare>();
        }

        // metoder
        public Vare Add(Vare vare)
        {
            _varer.Add(vare);

            return vare;
        }

        public List<Vare> GetAll()
        {
            return new List<Vare>(_varer);
        }

        public Vare Get(int id)
        {
            Vare? vare = _varer.FirstOrDefault(p => p.Id == id);
            if (vare == null)
            {
                throw new KeyNotFoundException($"Vare with id {id} not found.");
            }
            return vare;
        }

        public Vare Delete(int id)
        {
            Vare vare = Get(id);

            _varer.Remove(vare);
            return vare;
        }

        public Vare Update(int id, Vare updatedVare)
        {
            Vare vare = Get(id);
            int ix = _varer.IndexOf(vare);

            updatedVare.Id = id;
            _varer[ix] = updatedVare;
            return updatedVare;
        }


    }
}
