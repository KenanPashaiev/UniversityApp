using System.Data;

namespace UniversityApp.Forms.Service.Abstractions
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        protected readonly IDataAccessProvider DataAccessProvider;

        protected RepositoryBase()
        {
            DataAccessProvider = new DataAccessProvider();
        }

        public abstract void Create(T entity);

        public abstract void Delete(int id);

        public abstract void Update(T entity);

        public abstract DataTable FindAll();
    }
}
