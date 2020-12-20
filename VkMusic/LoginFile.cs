using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace VkMusic
{
    //для записи и хранения данных для входа
    class LoginFile
    {
        //запись логина и пароля в корень диска C: Б - безопасность.
        public static void RecLog(string l,string p)
        {
            FileStream fs = new FileStream(@"C:\VkMusicDate.txt", FileMode.OpenOrCreate);
            fs.Close();
            File.WriteAllLines(@"C:\VkMusicDate.txt", new string[] { l, p }, Encoding.UTF8);
        }
        //удаление логина и пароля из файла при выходе из учётки
        public static void DelLog()
        {
            FileStream fs = new FileStream(@"C:\VkMusicDate.txt", FileMode.OpenOrCreate);
            fs.Close();
            FileStream fs1 = new FileStream(@"C:\VkMusicDate.txt", FileMode.Truncate);
            
            fs1.Close();
        }
        //чтение логина и пароля
        public static string[] ReadLog()
        {
            FileStream fs = new FileStream(@"C:\VkMusicDate.txt", FileMode.OpenOrCreate);
            fs.Close();
            string[] res = File.ReadAllLines(@"C:\VkMusicDate.txt");
            return res;
        }
        //установка значения для сохранения пароля
        public static void RecAuto(bool auto)
        {
            FileStream fs1 = new FileStream(@"C:\VkMusicDateAuto.txt", FileMode.OpenOrCreate);
            string arr;
            if (auto)
            {
                arr = "1";
            }
            else
            {
                arr = "0";
            }
            byte[] log = System.Text.Encoding.Default.GetBytes(arr);
            fs1.Write(log, 0, log.Length);
            fs1.Close();
        }
        //чтение значения для автозаполнения
        public static bool ReadAuto()
        {
            byte[] auto = new byte[] {3 };
            string res="";
            FileStream fs1 = new FileStream(@"C:\VkMusicDateAuto.txt", FileMode.OpenOrCreate);
            try {
                fs1.Read(auto, 0, 1);
                fs1.Close();
                foreach (byte b in auto)res += b.ToString();
                if (res == "49") return true;
                return false;
            }
            catch
            {
                fs1.Close();
                return false;
            }
            
        }
        
    }
}
