using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_03_2
{
    internal class Passport
    {
        public int _PassportNumber;
        public string _FIO;
        public DateTime _date;

        public Passport(int passportNumber, string FIO, DateTime date)
        {
            _PassportNumber = passportNumber;
            _FIO = FIO;
            _date = date;

            Print();
        }

        public void Print()
        {
            try
            {
                int buffer = _PassportNumber;
                int k = 0;
                while (buffer > 0)
                {
                    buffer /= 10;
                    k++;
                }
                if (k != 7) throw new Exception("Неверный номер паспорта");
                else WriteLine($"Номер паспорта: {_PassportNumber}");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }

            try
            {
                string[] fio = _FIO.Split(' ');
                int k = 0;
                for (int i = 0; i < fio.Length; i++)
                {
                    k++;
                }
                if (k != 3) throw new Exception("ФИО ведено не прaвильно");
                else WriteLine($"ФИО: {_FIO}");
            }
            catch (Exception E)
            {
                WriteLine(E.Message);
            }

            WriteLine($"Дата выдачи: {_date}");
        }
    }
}
