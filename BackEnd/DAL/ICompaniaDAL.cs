using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public interface ICompaniaDAL : IDisposable
    {
        bool Add(Compania compania);
        bool Delete(int id);
        bool Update(Compania compania);
        List<Compania> Get();
        Compania Get(int id);
    }
}
