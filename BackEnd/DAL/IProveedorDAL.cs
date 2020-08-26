using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public interface IProveedorDAL : IDisposable
    {
        bool Add(Proveedor proveedor);
        bool Delete(int id);
        bool Update(Proveedor proveedor);
        List<Proveedor> Get();
        Proveedor Get(int id);
    }
}
