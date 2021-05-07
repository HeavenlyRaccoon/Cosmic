using Cosmic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cosmic.Services
{
    static class EntityFunction
    {
        public static string AddUser(string login, string password)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    if (context.Users.Where(t=>t.Login==login).Count()!=0)
                    {
                        return "Пользователь с таким логином уже существует";
                    }


                    var user = new User()
                    {
                        Login = login,
                        Password = GetHashString(password)

                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    return "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ex.Message;
            }
            
        }

        public static string Authorization(string login, string password)
        {
            try
            {
                string tmpPassword = GetHashString(password);
                using (var context = new MyDbContext())
                {
                    User user = context.Users.Where(t => t.Login == login && t.Password == tmpPassword).First();

                    return "";
                }
            }
            catch
            {
                return "Неверный логин или пароль";
            }
        }

        public static string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}
