using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DAL
{
    public class SucursalDALImpl : ISucursalDAL
    {

        private DBContext context;

        public bool Add(Sucursal Sucursal)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Sucursales.Add(Sucursal);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int idSucursale)
        {
            try
            {
                Sucursal Sucursal = this.Get(idSucursale);
                using (context = new DBContext())
                {
                    context.Sucursales.Attach(Sucursal);
                    context.Sucursales.Remove(Sucursal);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Sucursal> Get()
        {
            List<Sucursal> result;
            using (context = new DBContext())
            {
                result = (from c in context.Sucursales

                          select c).ToList();
            }
            return result;
        }

        public Sucursal Get(int id)
        {

            Sucursal result;
            using (context = new DBContext())
            {
                result = (from c in context.Sucursales
                          where c.id == id
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(Sucursal Sucursal)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Entry(Sucursal).State = System.Data.Entity.EntityState.Modified;
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
