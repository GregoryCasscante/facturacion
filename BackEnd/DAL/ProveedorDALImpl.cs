using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DAL
{
    public class ProveedorDALImpl : IProveedorDAL
    {

        private DBContext context;

        public bool Add(Proveedor proveedor)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Proveedores.Add(proveedor);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int idProveedor)
        {
            try
            {
                Proveedor proveedor = this.Get(idProveedor);
                using (context = new DBContext())
                {
                    context.Proveedores.Attach(proveedor);
                    context.Proveedores.Remove(proveedor);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Proveedor> Get()
        {
            List<Proveedor> result;
            using (context = new DBContext())
            {
                result = (from c in context.Proveedores

                          select c).ToList();
            }
            return result;
        }

        public Proveedor Get(int id)
        {

            Proveedor result;
            using (context = new DBContext())
            {
                result = (from c in context.Proveedores
                          where c.id == id
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(Proveedor proveedor)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Entry(proveedor).State = System.Data.Entity.EntityState.Modified;
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
