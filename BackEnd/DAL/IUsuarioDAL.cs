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
        bool Add(Usuario usuario);
        bool Delete(int id);
        bool Update(Usuario usuario);
        bool Create(Usuario usuario);
        List<Usuario> Get();
        Usuario Get(int id);
        Usuario Get(string usuario);
        Canton GetCanton(int id);
    }
}
