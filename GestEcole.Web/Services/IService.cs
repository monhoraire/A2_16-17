using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestEcole.Web.Services
{
    interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        void Save(T obj);

        void Delete(T obj);
    }
}
