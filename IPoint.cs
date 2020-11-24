using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnTap_KTLT
{
    public struct POINT
    {
        public int X;
        public int Y;
    }
    public class ser_Point
    {
        public static double Distance2Point(POINT a,POINT b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
                       
        }
        public static POINT CreatePoint(string stringPoint)
        {
            //01234
            //(x,y)
            stringPoint = stringPoint.Substring(1, stringPoint.Length - 2);
            var m = stringPoint.Split(',');

            POINT getSplit;
            getSplit.X = int.Parse(m[0]);
            getSplit.Y = int.Parse(m[1]);

            return getSplit;
        }

        public static void writePoint(POINT p,string filePath)
        {
            StreamWriter sw = new StreamWriter(filePath);
            sw.Write($"{p.X},{p.Y}");


            sw.Close();
        }
    }
}