using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnTap_KTLT
{
    public struct POLYGON
    {
        public POINT[] listPoint;
    }
    public class ser_Polygon
    {
        public static POLYGON readPolygon(string filePath)
        {
            List<POINT> listPoint = new List<POINT>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                string stringPoint = sr.ReadLine();
                var line = ser_Point.CreatePoint(stringPoint);
                listPoint.Add(line);
            }
            sr.Close();
            POLYGON dg;
            dg.listPoint = listPoint.ToArray();

            return dg;
        }


        public static POLYGON CreatePolygon(string stringPoint)
        {
            //"(0,0)|(1,0)|(0,1)"
            var listStringPoint = stringPoint.Split('|');
            POLYGON pol;
            pol.listPoint = new POINT[listStringPoint.Length];
            for(int i = 0; i < listStringPoint.Length; i++)
            {
                pol.listPoint[i] = ser_Point.CreatePoint(listStringPoint[i]);
            }
            return pol;

        }

        public static double PolygonPerimeter(POLYGON dg)
        {
            double result = 0;
            for (int i = 0; i < dg.listPoint.Length - 1; i++)
            {
                result = result + ser_Point.Distance2Point(dg.listPoint[i], dg.listPoint[i + 1]);
            }
            result = result + ser_Point.Distance2Point(dg.listPoint[0], dg.listPoint[dg.listPoint.Length-1]);
            return result;
        }

       
    }
}