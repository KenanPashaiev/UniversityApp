using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Entities;

namespace UniversityApp.Forms.Service.Abstractions
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        protected readonly DataAccessProvider DataAccessProvider;

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
