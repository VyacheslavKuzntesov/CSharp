using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    internal class Program
    {
        delegate void method();
        static void Main(string[] args)
        {

            string[] items = { "Задание 1", "Задание 2", "Задание 3", "Задание 4", "Задание 5", "Задание 6", "Задание 7", "Выход" };
            method[] methods = new method[] { Method1, Method2, Method3, Method4, Method5, Method6, Method7, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult != items.Length - 1);
        }

        static void Method1()
        {
            Console.Clear();
            int num = 0;
            Console.Write("Введите число в диапазоне от 1 до 100: ");
            num = Int32.Parse(Console.ReadLine());
            if (num < 1 || num > 100) Console.WriteLine($"Ошибка: число {num} не входит в диапозон от 1 до 100");
            else if (num % 3 == 0 && num % 5 == 0) Console.WriteLine("Fizz Buzz");
            else if (num % 3 == 0) Console.WriteLine("Fizz");
            else if (num % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine(num);
        }
        static void Method2()
        {
            Console.Clear();
            int proc = 1;
            double num = 0;
            Console.Write("Введите число: ");
            num = Double.Parse(Console.ReadLine());
            Console.Write("Введите процент: ");
            proc = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"{proc}% от числа {num} = {(num / 100) * proc}");
        }
        static void Method3()
        {
            int num = 0;
            for (int i = 0; i < 4; i++)
            {
                Console.Clear();
                Console.Write($"Введите {4 - i} число: ");
                num = num * 10 + Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Получилось число {num}");
        }
        static void Method4()
        {
            Console.Clear();
            Console.Write("Введите число: ");
            int num = Int32.Parse(Console.ReadLine());
            if (num < 100000 || num > 999999) Console.WriteLine("вы ввели не шестизначное число");
            else
            {
                Console.WriteLine($"Введите номера разрядов для обмена цифр: ");
                int raz1 = Int32.Parse(Console.ReadLine());
                int raz2 = Int32.Parse(Console.ReadLine());

                int chislo1 = 0;
                int del = 10;

                if (raz1 == 6) chislo1 = num % 10;
                else
                {
                    for (int i = 0; i < (6 - raz1); i++)
                    {
                        chislo1 = num / del;
                        del *= 10;
                    }
                    chislo1 = chislo1 % 10;
                    del = 10;
                }

                int chislo2 = 0;

                if (raz2 == 6) chislo2 = num % 10;
                else
                {
                    for (int i = 0; i < (6 - raz2); i++)
                    {
                        chislo2 = num / del;
                        del *= 10;
                    }
                    chislo2 = chislo2 % 10;
                }

                Console.WriteLine(chislo1);
                Console.WriteLine(chislo2);
                del = 100000;
                for (int i = 0; i < 6; i++)
                {
                    if (i == raz1-1)
                    {
                        Console.Write(chislo2);
                        num = num % del;
                        del /= 10;
                    }
                    else if (i == raz2-1)
                    {
                        Console.Write(chislo1);
                        num = num % del;
                        del /= 10;
                    }
                    else if (i == 5) Console.Write(num);
                    else
                    {
                        Console.Write(num / del);
                        num %= del;
                        del /= 10;
                    }
                }
            }
            Console.WriteLine();
        }
        static void Method5()
        {
            int day_of_week = 6;
            bool vusokosnuy = true;
            bool day_of_month = true;
            Console.Clear();
            Console.WriteLine("Введите число: ");
            int day = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите месяц: ");
            int month = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите год: ");
            int year = Int32.Parse(Console.ReadLine());
            bool dostup = true;

            if (day > 28 && month == 2)
            {
                Console.WriteLine("Введена неправильная дата(в этом году в феврале 28 дней)");
                dostup = false;
            }
            else if (day > 29 && month == 2 && year % 4 == 0)
            {
                Console.WriteLine("Введена неправильная дата(в этом году в феврале 29 дней)");
                dostup = false;
            }
            else if (day > 31)
            {
                Console.WriteLine("Введена неправильная дата(В году не может быть больше 31 дня)");
                dostup = false;
            }
            else if (day < 0)
            {
                Console.WriteLine("Введена неправильная дата(В году не может быть меньше 1 дня)");
                dostup = false;
            }
            else if (month > 12 || month < 1)
            {
                Console.WriteLine("Введена неправильная дата(Месяц)");
                dostup = false;
            }

            if (dostup)
            {

                for (int i = 1922; i <= year; i++)
                {

                    if (i % 4 == 0 && i % 100 != 0 || i % 400 == 0) vusokosnuy = true;
                    else vusokosnuy = false;

                    if (i != year)
                    {
                        for (int j = 1; j <= 12; j++)
                        {
                            if (j == 2 && vusokosnuy)
                            {
                                for (int daym = 1; daym <= 29; daym++)
                                {
                                    day_of_week++;
                                    if (day_of_week > 7) day_of_week = 1;
                                }
                                day_of_month = !day_of_month;
                            }
                            else if (j == 2 && !vusokosnuy)
                            {
                                for (int daym = 1; daym <= 28; daym++)
                                {
                                    day_of_week++;
                                    if (day_of_week > 7) day_of_week = 1;
                                }
                                day_of_month = !day_of_month;
                            }
                            else if (j == 12)
                            {
                                for (int daym = 1; daym <= 31; daym++)
                                {
                                    day_of_week++;
                                    if (day_of_week > 7) day_of_week = 1;
                                }
                                day_of_month = true;
                            }
                            else if (j == 7)
                            {
                                for (int daym = 1; daym <= 31; daym++)
                                {
                                    day_of_week++;
                                    if (day_of_week > 7) day_of_week = 1;
                                }
                            }
                            else if (day_of_month)
                            {
                                for (int daym = 1; daym <= 31; daym++)
                                {
                                    day_of_week++;
                                    if (day_of_week > 7) day_of_week = 1;
                                }
                                day_of_month = !day_of_month;
                            }
                            else if (!day_of_month)
                            {
                                for (int daym = 1; daym <= 30; daym++)
                                {
                                    day_of_week++;
                                    if (day_of_week > 7) day_of_week = 1;
                                }
                                day_of_month = !day_of_month;
                            }

                        }
                    }
                    else if (i == year)
                    {
                        for (int j = 1; j <= month; j++)
                        {
                            if (j != month)
                            {
                                if (j == 2 && vusokosnuy)
                                {
                                    for (int daym = 1; daym <= 29; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = !day_of_month;
                                }
                                else if (j == 2 && !vusokosnuy)
                                {
                                    for (int daym = 1; daym <= 28; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = !day_of_month;
                                }
                                else if (j == 12)
                                {
                                    for (int daym = 1; daym <= 31; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = true;
                                }
                                else if (j == 7)
                                {
                                    for (int daym = 1; daym <= 31; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                }
                                else if (!day_of_month)
                                {
                                    for (int daym = 1; daym <= 30; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = !day_of_month;
                                }
                                else if (day_of_month)
                                {
                                    for (int daym = 1; daym <= 31; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = !day_of_month;
                                }
                            }
                            else if (j == month)
                            {
                                if (j == 2 && vusokosnuy && day <= 29)
                                {
                                    for (int daym = 1; daym <= day; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = !day_of_month;
                                }
                                else if (j == 2 && !vusokosnuy && day <= 28)
                                {
                                    for (int daym = 1; daym <= day; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = !day_of_month;
                                }
                                else if (j == 12 && day <= 31)
                                {
                                    for (int daym = 1; daym <= 31; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = true;
                                }
                                else if (j == 7 && day <= 31)
                                {
                                    for (int daym = 1; daym <= 31; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                }
                                else if (day_of_month && day <= 31)
                                {
                                    for (int daym = 1; daym <= day; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = !day_of_month;
                                }
                                else if (!day_of_month && day <= 30)
                                {
                                    for (int daym = 1; daym <= day; daym++)
                                    {
                                        day_of_week++;
                                        if (day_of_week > 7) day_of_week = 1;
                                    }
                                    day_of_month = !day_of_month;
                                }
                                else Console.WriteLine("Введена неправильная дата!(В месяце который вы указали меньше дней)");
                            }
                        }
                    }
                }

                string season = null;
                string week = null;

                if (month == 1 || month == 2 || month == 12) season = "Зима";
                else if (month == 3 || month == 4 || month == 5) season = "Весна";
                else if (month == 6 || month == 7 || month == 8) season = "Лето";
                else if (month == 9 || month == 10 || month == 11) season = "Осень";

                //day_of_week++;
                //if (day_of_week > 7) day_of_week = 1;
                if (day_of_week == 1) week = "Понедельник";
                else if (day_of_week == 2) week = "Вторник";
                else if (day_of_week == 3) week = "Среда";
                else if (day_of_week == 4) week = "Четверг";
                else if (day_of_week == 5) week = "Пятница";
                else if (day_of_week == 6) week = "Суббота";
                else if (day_of_week == 7) week = "Воскресенье";

                Console.WriteLine($"День недели {week} сезон {season}");
            }
        }
        static void Method6()
        {
            method[] methods1 = new method[] { MethodTemp, MethodTemp1, ExitTemp };
            string[] items = { "Перевод из цельсия в фаренгей", "Перевод из фаренгейта в цельсий", "Выход" };
            ConsoleMenu menu1 = new ConsoleMenu(items);
            int menuResult1;
            do
            {
                menuResult1 = menu1.PrintMenu();
                methods1[menuResult1]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult1 != items.Length - 1);

            void MethodTemp()
            {
                Console.Clear();
                double C = 0;
                Console.Write("Введите температуру в цельсиях: ");
                C = Double.Parse(Console.ReadLine());
                Console.WriteLine($"{C}С = {C * 1.8 + 32}F");
            }
            void MethodTemp1()
            {
                Console.Clear();
                double F = 0, fraction = (double)5 / 9;
                Console.Write("Введите температуру в фаренгейтах: ");
                F = Double.Parse(Console.ReadLine());
                Console.WriteLine($"{F}F = {(F - 32) * fraction}C");
            }
            void ExitTemp()
            {
                Console.WriteLine("Выход!");
            }
        }
        static void Method7()
        {
            Console.Clear();
            int min = 0, max = 0;
            Console.Write("Введите минимальное значение диапазона: ");
            min = Int32.Parse(Console.ReadLine());
            Console.Write("Введите максимальное значение диапазона: ");
            max = Int32.Parse(Console.ReadLine());
            if (min > max)
            {
                int buffer = min;
                min = max;
                max = buffer;
            }
            for (int i = min; i <= max; i++)
            {
                if (i % 2 == 0) Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        static void Exit()
        {
            Console.WriteLine("Приложение заканчивает работу!");
        }
    }


    class ConsoleMenu
    {
        string[] menuItems;
        int counter = 0;
        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(menuItems[i]);

                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}
