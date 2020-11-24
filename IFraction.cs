using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnTap_KTLT
{
    public struct FRACTION
    {
        public int numerator;
        public int denomirator;
    }
    public class ser_Fraction
    {
        public static FRACTION AddTwoFraction(FRACTION frac1,FRACTION frac2)
        {
            FRACTION kq;

            kq.numerator = frac1.numerator * frac2.denomirator + frac2.denomirator * frac1.numerator;
            kq.denomirator = frac1.denomirator * frac2.denomirator;
            
            return kq;
           
        }
        public static FRACTION Create(string stringFrac)
        {
            var listStringFrac = stringFrac.Split('/');

            FRACTION getSplit;
            getSplit.numerator = int.Parse(listStringFrac[0]);
            getSplit.denomirator = int.Parse(listStringFrac[1]);

            return getSplit;
        }


        public static FRACTION readFraction(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            string s = sr.ReadLine();

            sr.Close();
            return Create(s);
        }

    }
}