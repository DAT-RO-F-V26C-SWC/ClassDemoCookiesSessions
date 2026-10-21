using SessionLib.model;

namespace SessionLib.repository
{
    public interface IVarerRepo
    {
        Vare Add(Vare vare);
        Vare Delete(int id);
        Vare Get(int id);
        List<Vare> GetAll();
        Vare Update(int id, Vare updatedVare);
    }
}