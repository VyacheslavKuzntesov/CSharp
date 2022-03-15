using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_03
{
    internal class Program
    {
        static void Squar(int Length, string symbol)
        {
            for (int i = 0; i < Length; i++, Console.WriteLine())
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write($"{symbol} ");
                }
            }
            Console.WriteLine();
        }

        static bool Palindrom(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)

                if (s[i] != s[s.Length - i - 1])
                    return false;
            return true;
        }

        static void Delete(ref int[] array, int[] array2)
        {
            List<int> Result = array.ToList();

            for (int i = 0; i < array2.Length; i++)
            {
                for (int j = 0; j < Result.Count; j++)
                {
                    if(Result[j] == array2[i])
                    {
                        Result.RemoveAt(j);
                    }
                }
            }
            array = Result.ToArray();
        }

        public class Web_site
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string Description { get; set; }
            public string Ip { get; set; }

            public override string ToString()
            {
                return $"{Name} {Url} {Description} {Ip}";
            }
        }

        public class Journal
        {
            public string Name { get; set; }
            public DateTime year_of_foundation { get; set; }
            public string Description { get; set; }
            public string Telephone { get; set; }
            public string e_mail { get; set; }
            public override string ToString()
            {
                return $"{Name} {year_of_foundation} {Description} {Telephone} {e_mail}";
            }
        }

        public class Shop
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Description { get; set; }
            public string Telephone { get; set; }
            public string e_mail { get; set; }
            public override string ToString()
            {
                return $"{Name} {Address} {Description} {Telephone} {e_mail}";
            }
        }

        static void Main(string[] args)
        {

#if Zadanie1
            int Length = 0;
            string symbol;

            Console.Write("Введите размер стороны: ");
            Length = Int32.Parse(Console.ReadLine());

            Console.Write("Введите символ: ");
            symbol = Console.ReadLine();

            Squar(Length, symbol); 
#endif

#if Zadanie2
            string s;
            Console.Write("Введите число: ");
            s = Console.ReadLine();

            Console.WriteLine(Palindrom(s)); 
#endif

#if Zadanie3
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] array2 = new int[] { 2, 5 };
            Delete(ref array, array2);
            foreach (int i in array)
                Console.WriteLine(i); 
#endif

        }
    }
}
