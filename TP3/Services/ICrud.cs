using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface ICrud<T> where T :class
    {
        T Create();

        void Read(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> ListAll();
    }
}
