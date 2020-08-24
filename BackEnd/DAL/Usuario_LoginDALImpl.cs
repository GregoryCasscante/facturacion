using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DAL
{
    public class Usuario_LoginDALImpl : IUsuario_LoginDAL
    {

        private DBContext context;

        public bool Add(Usuarios_Login Usuarios_Login)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Usuarios_Logins.Add(Usuarios_Login);
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
                Usuarios_Login Usuarios_Login = this.Get(id);
                using (context = new DBContext())
                {
                    context.Usuarios_Logins.Attach(Usuarios_Login);
                    context.Usuarios_Logins.Remove(Usuarios_Login);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Usuarios_Login> Get()
        {
            List<Usuarios_Login> result;
            using (context = new DBContext())
            {
                result = (from c in context.Usuarios_Logins
                          select c).ToList();
            }
            return result;
        }

        public Usuarios_Login Get(int id)
        {

            Usuarios_Login result;
            using (context = new DBContext())
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
