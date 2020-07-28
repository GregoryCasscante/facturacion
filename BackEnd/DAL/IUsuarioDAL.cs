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
        bool Add(Usuario category);
        bool Delete(int idCategory);
        bool Update(Usuario category);
        List<Usuario> Get();
        Usuario Get(int idCategory);

    }
}
