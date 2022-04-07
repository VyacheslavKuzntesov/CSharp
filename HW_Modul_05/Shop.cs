using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_05
{
    internal class Shop
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double Square { get; set; }

        public static Shop operator +(Shop w, int num)
        {
            return new Shop { Square = w.Square + num };
        }
        public static Shop operator -(Shop w, int num)
        {
            return new Shop { Square = w.Square + num };
        }
        public static bool operator ==(Shop w, Shop s)
        {
            if (w.Square == s.Square)
                return true;
            else return false;
        }
        public static bool operator !=(Shop w, Shop s)
        {
            return !w.Square.Equals(s.Square);
        }
        public static bool operator <(Shop w, Shop s)
        {
            if (w.Square < s.Square)
                return true;
            else return false;
        }
        public static bool operator >(Shop w, Shop s)
        {
            if (w.Square > s.Square)
                return true;
            else return false;
        }

        public void Print()
        {
            Write($"Название магазина: {Name}" +
                $"Адрес магазина: {Adress}" +
                $"Описание магазина {Description}: " +
                $"Номер телефона магазина: {Phone}" +
                $"E-mail: {Email}" +
                $"Площадь магазина: {Square} м.кв");
        }
        public override bool Equals(object obj)
        {
            Shop shop = (Shop)obj;
            return (Square == shop.Square);
        }
    }
}
