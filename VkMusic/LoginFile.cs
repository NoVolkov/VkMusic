using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace VkMusic
{
    class LoginFile
    {
        public static void RecLog(string l,string p)
        {
            FileStream fs1 = new FileStream(@"C:\VkMusicDate.txt", FileMode.OpenOrCreate);
            string arr = l + "\n" + p+"\0";
            byte[] log = System.Text.Encoding.Default.GetBytes(arr);
            fs1.Write(log,0,log.Length);
            fs1.Close();
        }
        public static void DelLog()
        {
            FileStream fs1 = new FileStream(@"C:\VkMusicDate.txt", FileMode.Truncate);
            
            fs1.Close();
        }
        public static string[] ReadLog()
        {
            string[] res = File.ReadAllLines(@"C:\VkMusicDate.txt");
            return res;
            /*FileStream fs1 = new FileStream(@"C:\VkMusicDate.txt", FileMode.OpenOrCreate);
            byte[] auto = new byte[] {0};
            int n;
            for(int i = 0; i < 256; i++)
            {
                n=fs1.Read(auto, 0, 2);
                if (n == (int)'\0')
                {
                    break;
                }
            }
            string l = "", p = "";
            bool t = true;
            foreach(byte b in auto)
            {
                if (b!=10 && t)
                {
                    l += b.ToString();
                }
                else
                {
                    p += b.ToString();
                }
            }
            res[0] = l;
            res[1] = p;
            return res;
            
            
            */
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            /*char[] auto = new char[] { };
            
            int j,n=0;
            for (int i= 0; i < 256; i++){
                j= fs1.ReadByte();
                if (j != '\0')
                {
                    auto[i] = (char)j;
                }
                else
                {
                    break;
                }
                n++;
            }

            //fs1.Read(auto, 0, 256);
            fs1.Close();

            string l = "", p = "";
            bool t = true;
            foreach (char b in auto)
            {
                if (b != 10 && t)
                {
                    l += b.ToString();
                }
                else
                {
                    if (b != auto[n])
                    {
                        t = false;
                        p += b.ToString();
                    }
                    else
                    {
                        break;
                    }
                    
                }
            }
            res[0] = l;
            res[1] = p;
            return res;*/
        }

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
