using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OnTap_KTLT
{
    
    public class DAL_Book
    {
        private static string filePath = "D:\\TXT\\DOCDSSACH.txt";
        public static void dal_WriteBook(BOOK b)
        {
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine(b.ID);
            sw.WriteLine(b.Name);
            sw.WriteLine(b.Price);
            sw.WriteLine(b.Author);
            sw.WriteLine(b.PublishingYear);

            sw.Close();
        }
        public static void AddBook(BOOK book)
        {
            var lsBook = readListBooks(string.Empty);
            lsBook.Add(book);
            saveListBooks(lsBook);
        }
        public static void saveListBooks(List<BOOK> lsbook)
        {
            StreamWriter sw = new StreamWriter(filePath);
            for(int i = 0;i < lsbook.Count; i++)
            {
                var s = lsbook[i];
                string line = $"{s.ID},{s.Name},{s.Price},{s.Author},{s.PublishingYear}";
                if (i == lsbook.Count - 1)
                {
                    sw.Write(line);
                }
                else
                    sw.WriteLine(line);
            }

            sw.Close();
        }

        public static List<BOOK> readListBooks(string keyword)
        {
            List<BOOK> listBooks = new List<BOOK>();
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var books = ser_Book.splitStringBook(line);
                if (string.IsNullOrEmpty(keyword) || books.Name.Contains(keyword))
                {
                    listBooks.Add(books);
                }
            }

            sr.Close();
            return listBooks;
        }
        public static void deleteBook(int ID)
        {
            //Gọi hàm search ds sach de hien thi list sách ma khong can dieu kien
            //Đọc danh sách của sách mà không thêm điều kiện
            //string.Empty
            var listBooks = readListBooks(string.Empty);
            foreach(var book in listBooks)
            {
                if(book.ID == ID)
                {
                    listBooks.Remove(book);
                    break;
                }
                
            }
            saveListBooks(listBooks);       
        }
    }
}