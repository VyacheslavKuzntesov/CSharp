using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_06
{
    internal class Money
    {
        public int Price;
        public int kop;
        public string money;

        public Money()
        {
            Write("Введите вылюту: "); money = ReadLine();
            Write("Введите целую часть: "); Price = int.Parse(ReadLine());
            Write("Введите копейки: "); kop = int.Parse(ReadLine());
            if (kop >= 100) Price += kop / 100;
            kop %= 100;
        }

        public Money(int wp, int k, string mon)
        {
            Price = wp;
            if (k >= 100) Price += k / 100;
            kop = k % 100;
            money = mon;
        }

        public void Print()
        {
            WriteLine($"У вас {Price},{kop} {money}");
        }
    }
    class Product : Money
    {
        string product;
        public Product(string name, int wp, int k, string mon) : base(wp, k, mon)
        {
            product = name;
        }
        public void Reduce_the_price(Money b)
        {
            try
            {
                if (this.money != b.money) throw new Exception("Разная валюта");
                else
                {
                    if (b.Price > this.Price) this.Price = 0;
                    else
                    {
                        if (b.kop > this.kop)
                        {
                            this.Price = this.Price - b.Price - 1;
                            this.kop = 100 - (b.kop - this.kop);
                        }
                        else
                        {
                            this.Price = this.Price - b.Price;
                            this.kop = (this.kop - b.kop) / 100;
                        }
                    }
                }
            }
            catch (Exception e)
            { WriteLine(e.Message); }
        }

        public void Print()
        {
            WriteLine($"Продукт: {product} стоит  {Price},{kop} {money}");
        }

    }
}
