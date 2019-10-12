using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Forms.Service.Abstractions
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        public virtual void Create(T entity)
        {

        }

        public virtual void Delete(int id)
        {

        }

        public virtual void Update(T entity)
        {

        }

        public virtual DataTable FindAll()
        {
            return null;
        }
    }
}
