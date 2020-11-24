using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;


namespace OnTap_KTLT
{
    public class DAL_Book_json
    {
        private static string filePath = "D:\\TXT\\WriteBook_JSON.json";

        public static void write_JSON(BOOK book)
        {
            JavaScriptSerializer t = new JavaScriptSerializer();
            string json = t.Serialize(book);


            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(json);
            sw.Close();
        }
    }
}