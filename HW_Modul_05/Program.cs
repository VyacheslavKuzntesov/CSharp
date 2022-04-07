using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List_of_books s = new List_of_books(new[]
            {
                new Book("12","412"),
                new Book("qwer","tyu"),
                new Book("a123","oad23p")
            });

            s.Print();
            WriteLine();

            s.AddBooks();
            s.Print();

            s.Remove();
            s.Print();

            WriteLine();
            try
            {
                WriteLine($"Поиск по названию: {s["qwer"]}");
                WriteLine($"Поиск по автору: {s["412"]}");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

        }
    }
}
