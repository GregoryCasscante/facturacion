using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEnd.Libraries;



namespace PruebasBackEnd
{
    [TestClass]
    public class TestUsuarioDAL
    {
        [TestMethod]
        public void TestAdd()
        {
            IUsuarioDAL usuarioDAL = new UsuarioDALImpl();

            Usuario usuario = new Usuario
            {
                estado = 1
            };

            Auth auth = new Auth();

            Console.WriteLine("HOLA");
            Console.WriteLine(auth.generarSalt());

            //Assert.AreEqual(true, categoryDAL.Add(category));
        }
    }
}
