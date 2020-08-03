using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL 
{
    public interface IUsuario_LoginDAL : IDisposable
    {
        bool Add(Usuario_Login Usuario_Login);
        bool Delete(int id);
         List<Usuario_Login> Get();
        Usuario_Login Get(int id);
    }
}
