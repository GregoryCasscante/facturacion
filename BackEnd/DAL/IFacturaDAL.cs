using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public interface IFacturaDAL : IDisposable
    {
        int Add(Factura cliente);
        int Add_Linea(Detalle_Factura detalle);
        bool Delete(int id);
        bool Update(Factura cliente);
        List<Factura> Get();
        Factura Get(int id);
    }
}
