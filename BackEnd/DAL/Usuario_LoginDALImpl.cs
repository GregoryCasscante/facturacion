using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DAL
{
    public class Usuario_LoginDALImpl : IUsuario_LoginDAL
    {

        private BDContext context;

        public bool Add(Usuario_Login Usuario_Login)
        {
            try
            {
                using (context = new BDContext())
                {
                    context.Usuarios_Logins.Add(Usuario_Login);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                Usuario_Login Usuario_Login = this.Get(id);
                using (context = new BDContext())
                {
                    context.Usuarios_Logins.Attach(Usuario_Login);
                    context.Usuarios_Logins.Remove(Usuario_Login);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Usuario_Login> Get()
        {
            List<Usuario_Login> result;
            using (context = new BDContext())
            {
                result = (from c in context.Usuarios_Logins
                          select c).ToList();
            }
            return result;
        }

        public Usuario_Login Get(int id)
        {

            Usuario_Login result;
            using (context = new BDContext())
            {
                result = (from c in context.Usuarios_Logins
                          where c.login_id == id
                          select c).FirstOrDefault();
            }
            return result;
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
