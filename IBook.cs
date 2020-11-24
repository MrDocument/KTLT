using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace OnTap_KTLT
{
    public struct BOOK
    {
        public int ID;
        public string Name;
        public int Price;
        public string Author;
        public int PublishingYear;
    }
    public class ser_Book
    {    
        public static void writeBook(BOOK s)
        {
            if(s.Price >= 20 && s.Price <= 500)
            {
                //DAL_Book.dal_WriteBook(s);
                //DAL_Book_json.write_JSON(s);
                DAL_Book.AddBook(s);
            }
        }
        public static BOOK readBook(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            BOOK b;
            b.ID = int.Parse(sr.ReadLine());
            b.Name = sr.ReadLine();
            b.Price = int.Parse(sr.ReadLine());
            b.Author = sr.ReadLine();
            b.PublishingYear = int.Parse(sr.ReadLine());

            sr.Close();
            return b;
        }
             
        public static List<BOOK> readListBooks(string keyword)
        {
            List<BOOK> listBooks = new List<BOOK>();
            listBooks = DAL_Book.readListBooks(keyword);

            return listBooks;
        }

        public static BOOK splitStringBook(string stringBooks)
        {
            var m = stringBooks.Split(',');
            BOOK book;
            book.ID = int.Parse(m[0]);
            book.Name = m[1];
            book.Price = int.Parse(m[2]);
            book.Author = m[3];
            book.PublishingYear = int.Parse(m[4]);


            return book; 
        }
        public static void deleteBook(int ID)
        {
            DAL_Book.deleteBook(ID);
        }
        public static BOOK readBookUpdate(int ID)
        {
            BOOK result = new BOOK();
            var listBooks = readListBooks(string.Empty);
            foreach (var s in listBooks)
            {
                if (s.ID == ID)
                {
                    result = s;
                    break;
                }
            }
            return result;
        }
        public static void updateBook(BOOK b)
        {

            var listBooks = readListBooks(string.Empty);
            foreach (var book in listBooks)
            {
                if (book.ID == b.ID)
                {
                    listBooks.Remove(book);
                    listBooks.Add(b);
                    break;
                }
            }
            DAL_Book.saveListBooks(listBooks);
        }
    }


}