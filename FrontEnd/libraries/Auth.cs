using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.libraries
{

    public class Auth
    {
/*
        private ProyWebContext db = new DBContext();

        public Auth()
        {

        }

        public Boolean Login(string cod_usuario, string clave)
        {

            // Query for the Blog named ADO.NET Blog
            var user = db.usuarios
                            .Where(b => b.cod_usuario == cod_usuario)
                            .FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            else
            {
                if (String.Equals(cod_usuario, user.cod_usuario) & String.Equals(clave, user.clave))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }


        public string Encrypt()
        {
            try
            {
                string textToEncrypt = "Water";
                string ToReturn = "";
                string publickey = "3zeSRY0DWPZmcwVf54LZRBoZ3AuJHyoX";
                string secretkey = "VzFExWZ50kRwiY7laXBu6aey13PYct13";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public string Decrypt()
        {
            try
            {
                string textToDecrypt = "VtbM/yjSA2Q=";
                string ToReturn = "";
                string publickey = "3zeSRY0DWPZmcwVf54LZRBoZ3AuJHyoX";
                string privatekey = "VzFExWZ50kRwiY7laXBu6aey13PYct13";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privatekey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }
*/
    }


}