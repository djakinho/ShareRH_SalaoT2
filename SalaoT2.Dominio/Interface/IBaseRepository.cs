using System;
using System.Collections.Generic;
using System.Text;

namespace SalaoT2.Dominio.Interface
{
    public interface IBaseRepository<T> where T : class, IEntity
    {

    }
}
