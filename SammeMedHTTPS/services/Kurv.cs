using SammeMedHTTPS.util;

namespace SammeMedHTTPS.services
{
    public class Kurv
    {
        // instans felter
        private List<VareWithCount> _varer;


        // til serialisering
        public List<VareWithCount> Varer
        {
            get { return _varer; }
            set { _varer = value; }
        }

        // constructor
        public Kurv()
        {
            _varer = new List<VareWithCount>();
        }

        // metoder
        public void AddVare(VareWithCount vare)
        {
            _varer.Add(vare);
        }

        public void DeleteVare(int id)
        {
            var vare = _varer.FirstOrDefault(v => v.Id == id);
            if (vare != null)
            {
                _varer.Remove(vare);
            }
        }

        public List<VareWithCount> AllVarer()
        {
            return new List<VareWithCount>(_varer);
        }

        public void AddCountToVare(int id, int count)
        {
            var vare = _varer.FirstOrDefault(v => v.Id == id);
            if (vare != null)
            {
                vare.Count += count;
            }
        }

        public void ReduceCountFromVare(int id, int count)
        {
            var vare = _varer.FirstOrDefault(v => v.Id == id);
            if (vare != null)
            {
                vare.Count -= count;
                if (vare.Count <= 0)
                {
                    _varer.Remove(vare);
                }
            }
        }


    }
}
