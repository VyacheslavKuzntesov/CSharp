using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_03_2
{
    internal class Translating
    {
        string[] Number ={"zero","one","two","three","four","five","six","seven",
        "eight","nine"};
        int[] num = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public Translating()
        {
            bool proverka = false;

            Write("Введите цифру от 0 до 9 словом: ");
            string str = ReadLine().ToLower();

            for (int i = 0; i < Number.Length; i++)
            {
                if (Number[i] == str)
                {
                    WriteLine($"{str} это {num[i]}");
                    proverka = true;
                }
            }
            if (proverka == false) WriteLine("Проверьте текст");
        }
    }
}
