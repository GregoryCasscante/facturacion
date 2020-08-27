using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public interface ICategoriaProductoDAL : IDisposable
    {

        bool Add(Categorias_Productos categorias_Productos);
        bool Delete(int id);
        bool Update(Categorias_Productos categorias_Productos);
        List<Categorias_Productos> Get();
        Categorias_Productos Get(int id);

    }
}
