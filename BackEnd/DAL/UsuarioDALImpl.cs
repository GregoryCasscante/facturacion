using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.Entities;

namespace BackEnd.DAL
{
    public class UsuarioDALImpl : IUsuarioDAL
    {

        private BDContext context;

        public bool Add(Usuario Usuario)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.Usuarios.Add(Usuario);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int idCategory)
        {
            try
            {
                Usuario Usuario = this.Get(idCategory);
                using (context = new BDContext())
                {
                    context.Usuarios.Attach(Usuario);
                    context.Usuarios.Remove(Usuario);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Usuario> Get()
        {
            List<Usuario> result;
            using (context = new BDContext())
            {
                result = (from c in context.Usuarios

                          select c).ToList();
            }
            return result;
        }

        public Usuario Get(int id)
        {

            Usuario result;
            using (context = new BDContext())
            {
                result = (from c in context.Usuarios
                          where c.id == id
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(Usuario Usuario)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.Entry(Usuario).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
