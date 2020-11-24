using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnTap_KTLT
{
    public struct USER
    {
        public int ID;
        public string username;
        public string password;
    }

    public class IUSERS
    {

        public static USER Login(string username, string password)
        {
            USER user = DAL_Users.searchUsers(username);
            if (user.password == password)
            {
                return user;
            }
            return new USER();
        }
        public static USER splitStringUser(string UsersString)
        {
            var m = UsersString.Split(',');
            USER us;
            us.ID = int.Parse(m[0]);
            us.username = m[1];
            us.password = m[2];

            return us;
        }
        public static void Register(string username, string password)
        {

            var listUser = DAL_Users.readListUsers();
            USER user;
            user.username = username;
            user.password = password;

            int maxId = 0;
            foreach (USER us in listUser)
            {
                if (maxId < us.ID)
                {
                    maxId = us.ID;
                }
            }
            user.ID = maxId + 1;

            listUser.Add(user);
            DAL_Users.saveListUsers(listUser);
            

        }

    }
}