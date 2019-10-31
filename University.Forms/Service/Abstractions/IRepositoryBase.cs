using System.Data;

namespace UniversityApp.Forms.Service.Abstractions
{
    public interface IRepositoryBase<in T>
    {
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
        DataTable FindAll();
    }
}
