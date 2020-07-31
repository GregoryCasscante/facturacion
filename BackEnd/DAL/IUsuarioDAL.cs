using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public interface IUsuarioDAL : IDisposable
    {
        bool Add(Usuarios usuario);
        bool Delete(int id);
        bool Update(Usuarios usuario);
        List<Usuarios> Get();
        Usuarios Get(int id);

    }
}
