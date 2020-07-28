using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEnd.Libraries;


//https://medium.com/@mehanix/lets-talk-security-salted-password-hashing-in-c-5460be5c3aae
//https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp
//https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-3.1
//https://forums.asp.net/t/2155576.aspx?how+to+hash+salt+password+in+Register+and+Login
//https://blog.securityinnovation.com/blog/2011/03/how-to-hash-and-salt-passwords-in-aspnet.html

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
