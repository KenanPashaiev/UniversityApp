using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Forms.Service.Abstractions
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Delete(int id);
        void Update(T entity);
        DataTable FindAll();
    }
}
