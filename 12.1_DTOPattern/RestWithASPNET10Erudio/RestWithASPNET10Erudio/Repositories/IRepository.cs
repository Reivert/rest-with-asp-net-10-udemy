using RestWithASPNET10Erudio.Model;
using RestWithASPNET10Erudio.Model.Base;

namespace RestWithASPNET10Erudio.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        T FindById(long id);
        List<T> FindAll();
        void Delete(long id); 
        bool Exists(long id);
    }
}
