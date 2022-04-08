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
        public Translating()
        {
            bool proverka = false;

            Write("Введите цифру от 0 до 9 словом: ");
            string str = ReadLine().ToLower();

            for (int i = 0; i < Number.Length; i++)
            {
                if (Number[i] == str)
                {
                    WriteLine($"{str} это {i}");
                    proverka = true;
                }
            }
            if (proverka == false) WriteLine("Проверьте текст");
        }
    }
}
