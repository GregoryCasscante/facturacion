using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DAL
{
    public class FacturaDALImpl : ICompaniaDAL
    {

        private DBContext context;

        public bool Add(Compania compania)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Companias.Add(compania);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int idCompania)
        {
            try
            {
                Compania compania = this.Get(idCompania);
                using (context = new DBContext())
                {
                    context.Companias.Attach(compania);
                    context.Companias.Remove(compania);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Compania> Get()
        {
            List<Compania> result;
            using (context = new DBContext())
            {
                result = (from c in context.Companias

                          select c).ToList();
            }
            return result;
        }

        public Compania Get(int id)
        {

            Compania result;
            using (context = new DBContext())
            {
                result = (from c in context.Companias
                          where c.id == id
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(Compania compania)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Entry(compania).State = System.Data.Entity.EntityState.Modified;
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
