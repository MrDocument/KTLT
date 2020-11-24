using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnTap_KTLT
{
    public struct TRIANGLE
    {
        public POINT A;
        public POINT B;
        public POINT C;
    }
    public class ser_Triangle
    {
        public static double TrianglePerimeter(TRIANGLE tg)
        {
            double a, b, c;
            a = ser_Point.Distance2Point(tg.B, tg.C);
            b = ser_Point.Distance2Point(tg.C, tg.A);
            c = ser_Point.Distance2Point(tg.A, tg.B);

            double result = a + b + c;
            return result;
        }
        public static void writeTriangle(TRIANGLE tg)
        {
            if (LegalCheck(tg) == true)
            {
                DAL_Triangle.dal_WriteTriangle(tg);
            }
        }

        public static bool LegalCheck(TRIANGLE tg)
        {
            double a, b, c;
            a = ser_Point.Distance2Point(tg.B, tg.C);
            b = ser_Point.Distance2Point(tg.C, tg.A);
            c = ser_Point.Distance2Point(tg.A, tg.B);

            if (a + b > c && a + c > b && b + c > a)
            {
                return true;
            }
            return false;
        }
    }
}