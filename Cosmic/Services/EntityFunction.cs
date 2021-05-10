using Cosmic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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
                return ex.Message;
            }
            
        }

        public static User Authorization(string login, string password)
        {
            try
            {
                string tmpPassword = GetHashString(password);
                using (var context = new MyDbContext())
                {
                    User user = context.Users.Where(t => t.Login == login && t.Password == tmpPassword).First();

                    return user;
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool PasswordEqual(int id, string password)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    User user = context.Users.Where(t => t.Id==id).First();
                    if (user.Password == GetHashString(password))
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void ChangeUser(int id, string name, string aboutUser, string password, BitmapImage image)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    User user = context.Users.Where(t => t.Id == id).First();
                    user.Name = name;
                    user.AboutUser = aboutUser;
                    if (password != "")
                    {
                        user.Password = GetHashString(password);
                    }
                    byte[] data;
                    JpegBitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
                    bitmapEncoder.Frames.Add(BitmapFrame.Create(image));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bitmapEncoder.Save(ms);
                        data = ms.ToArray();
                    }
                    user.Avatar = data;
                    context.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("Change faild");
            }
        }


        public static BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
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
