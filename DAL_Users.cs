using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace OnTap_KTLT
{
    public class DAL_Users
    {
        private static string filePath = "D:\\TXT\\users.txt";
        public static USER searchUsers(string username)
        {
            
            StreamReader sr = new StreamReader(filePath);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                var user = IUSERS.splitStringUser(line);

                if(user.username == username)
                {
                    return user;
                }    
                
            }
            sr.Close();

            return new USER();

        }
        public static List<USER> readListUsers()
        {
            List<USER> list = new List<USER>();
            StreamReader sr = new StreamReader(filePath);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                var user = IUSERS.splitStringUser(line);

                list.Add(user);

            }
            sr.Close();
            return list;
        }
        public static void saveListUsers(List<USER> us)
        {
            StreamWriter sw = new StreamWriter(filePath);
            int i = 0;
            foreach(USER s in us)
            {
                
                sw.Write($"{s.ID},{s.username},{s.password}");
                i++;
                if(i<us.Count)
                {
                    sw.WriteLine();
                }
            }

            sw.Close();
        }
       
    }
}