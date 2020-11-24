using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace OnTap_KTLT
{
    public class DAL_Triangle
    {
        private static string filePath = "D:\\TXT\\writeTriangle.txt";

        public static void dal_WriteTriangle(TRIANGLE tg)
        {
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine($"({tg.A.X},{tg.A.Y})");
            sw.WriteLine($"({tg.B.X},{tg.B.Y})");
            sw.WriteLine($"({tg.C.X},{tg.C.Y})");


            sw.Close();
        }
    }
}