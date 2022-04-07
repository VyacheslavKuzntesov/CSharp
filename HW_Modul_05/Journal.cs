using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_05
{
    internal class Journal
    {
        public string Name { get; set; }
        public DateTime year_of_foundation { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int _count { get; set; }

        public static Journal operator +(Journal w, int num)
        {
            return new Journal { _count = w._count + num };
        }
        public static Journal operator -(Journal w, int num)
        {
            return new Journal { _count = w._count - num };
        }
        public static bool operator ==(Journal w, Journal s)
        {
            if (w._count == s._count)
                return true;
            else return false;
        }
        public static bool operator !=(Journal w, Journal s)
        {
            return !w._count.Equals(s._count);
        }
        public static bool operator <(Journal w, Journal s)
        {
            if (w._count < s._count)
                return true;
            else return false;
        }
        public static bool operator >(Journal w, Journal s)
        {
            if (w._count > s._count)
                return true;
            else return false;
        }


        //                        Methods:
        public void Print()
        {
            Write($"Название журнала: {Name}\n" +
                $"Год основания: {year_of_foundation}\n" +
                $"Описание журнала: {Description}\n" +
                $"Контактный телефон: {Phone}\n" +
                $"Контактный e-mail: {Email}\n" +
                $"Количество сотрудников: {_count}\n");
        }
        public override bool Equals(object obj)
        {
            Journal journal = (Journal)obj;
            return (_count == journal._count);
        }
    }
}
