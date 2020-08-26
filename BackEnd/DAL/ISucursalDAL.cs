using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public interface ISucursalDAL : IDisposable
    {

        bool Add(Sucursal sucursale);
        bool Delete(int id);
        bool Update(Sucursal sucursale);
        List<Sucursal> Get();
        Sucursal Get(int id);

    }
}
