using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.DAL
{
    public class ClienteDALImpl : IClienteDAL
    {

        private DBContext context;

        public bool Add(Cliente cliente)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Clientes.Add(cliente);
                    context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Delete(int idCliente)
        {
            try
            {
                Cliente cliente = this.Get(idCliente);
                using (context = new DBContext())
                {
                    context.Clientes.Attach(cliente);
                    context.Clientes.Remove(cliente);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Cliente> Get()
        {
            List<Cliente> result;
            using (context = new DBContext())
            {
                result = (from c in context.Clientes

                          select c).ToList();
            }
            return result;
        }

        public Cliente Get(int id)
        {

            Cliente result;
            using (context = new DBContext())
            {
                result = (from c in context.Clientes
                          where c.id == id
                          select c).FirstOrDefault();
            }
            return result;
        }

        public bool Update(Cliente cliente)
        {
            try
            {
                using (context = new DBContext())
                {
                    context.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
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
