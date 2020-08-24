using BackEnd.Entities;
using BackEnd.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DAL
{
    public class UsuarioDALImpl : IUsuarioDAL
    {

        private DBContext context;

        public bool Add(Usuario Usuario)
        {
            try
            {
                using (context = new DBContext())
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

        public bool Delete(int id)
        {
            try
            {
                Usuario Usuario = this.Get(id);
                using (context = new DBContext())
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
            using (context = new DBContext())
            {
                result = (from c in context.Usuarios

                          select c).ToList();
            }
            return result;
        }

        public Usuario Get(int id)
        {

            Usuario result;
            using (context = new DBContext())
            {
                result = (from c in context.Usuarios
                          where c.id == id
                          select c).FirstOrDefault();
            }
            return result;
        }

        public Usuario Get(string usurio)
        {

            Usuario result;
            using (context = new DBContext())
            {
                result = (from c in context.Usuarios
                          where c.usuario == usurio
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(Usuario Usuario)
        {
            try
            {
                using (context = new DBContext())
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

        public bool Create(Usuario usuario)
        {
            try
            {

                Auth auth     = new Auth();
                usuario.salt  = auth.generarSalt();
                usuario.clave = auth.hash_password(usuario.clave, usuario.salt);

                using (UnidadDeTrabajo<Usuario> unidad = new UnidadDeTrabajo<Usuario>(new DBContext()))
                {
                    unidad.genericDAL.Add(usuario);
                    unidad.Complete();
                }


                /*
                using (context = new DBContext())
                {

                    Auth auth    = new Auth();

                    //Encriptar Clave 
                    usuario.id = 12;
                    usuario.salt  = auth.generarSalt();
                    usuario.clave = auth.hash_password(usuario.clave, usuario.salt);

                    context.Usuario.Add(usuario);
                    context.SaveChanges();
                }
                */

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
