using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_02
{

    public class CaesarCipher
    {
        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string CodeEncode(string text, int k)
        {
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        //шифрование текста
        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);

        //дешифрование текста
        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }



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
            Random random = new Random();
            int[] arr = new int[5];
            double[,] arr2 = new double[3, 4];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Clear();
                Console.Write($"Введите {i + 1} элемент масива: ");
                arr[i] = Int32.Parse(Console.ReadLine());
                Console.Clear();
            }

            Console.Write("Массив введенный пользователем: ");
            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();

            for (int i = 0; i < arr2.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr2.Length / (arr2.GetUpperBound(0) + 1); j++)
                {
                    arr2[i, j] = (float)random.Next(0, 500) / 100;
                }
            }

            for (int i = 0; i < arr2.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr2.Length / (arr2.GetUpperBound(0) + 1); j++)
                {
                    Console.Write($"{arr2[i, j]} ");
                }
                Console.WriteLine();
            }

            int min1 = arr[0];
            int max1 = arr[0];
            double min2 = arr2[0,0];
            double max2 = arr2[0,0];
            double sum = 0;
            int sum4et = 0;
            double sumne4et = 0;
            double proz = 1;

            foreach (int i in arr)
            {
                if (i < min1) min1 = i;
                if (i > max1) max1 = i;
                sum += i;
                proz *= i;
                if (i % 2 == 0) sum4et += i;
            }
            for (int i = 0; i < arr2.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr2.Length / (arr2.GetUpperBound(0) + 1); j++)
                {
                    if ((j + 1) % 2 != 0) sumne4et += arr2[i, j];
                    if (arr2[i, j] > max2) max2 = arr2[i, j];
                    if (arr2[i, j] < min2) min2 = arr2[i, j];
                    sum += arr2[i, j];
                    proz *= arr2[i, j];
                }
            }
            Console.WriteLine(min1 == min2 ? $"Общий минимальный элемент: {min1}" : $"Общего минимального элемента нет");
            Console.WriteLine(max1 == max2 ? $"Общий максимальный элемент: {min1}" : $"Общего максимального элемента нет");
            Console.WriteLine($"Общая сумма элементов:{sum}\nОбщее произведение элементов:{proz}\nСумма четных элементов массива А:{sum4et}\nСумма нечетных столбцов массива В:{sumne4et}");

        }

        static void Method2()
        {
            Console.Clear();
            Random rand = new Random();
            int[,] arr = new int[5, 5];
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }

            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }

            int indexmini = 0;
            int indexminj = 0;
            int indexmaxi = 0;
            int indexmaxj = 0;
            int min = 0;
            int max = 0;
            int sum = 0;

            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        indexmini = i;
                        indexminj = j;
                    }
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        indexmaxi = i;
                        indexmaxj = j;
                    }
                }
            }

            if (indexmini>indexmaxi)
            {
                int buffer = indexmini;
                indexmini = indexmaxi;
                indexmaxi = buffer;
                buffer = indexmaxj;
                indexmaxj = indexminj;
                indexminj = buffer;
            }

            if((indexmini == indexmaxi) && (indexminj>indexmaxj))
            {
                int buffer = indexmini;
                indexmini = indexmaxi;
                indexmaxi = buffer;
                buffer = indexmaxj;
                indexmaxj = indexminj;
                indexminj = buffer;
            }

            for (int i = indexmini; i <= indexmaxi; i++)
            {
                if (indexmini == indexmaxi)
                {
                    for (int j = indexminj + 1; j < indexmaxj; j++) sum += arr[i, j];
                }
                else if (i == indexmini)
                {
                    for (int j = indexminj+1; j < arr.Length / (arr.GetUpperBound(0) + 1); j++) sum += arr[i, j];
                }
                else if (indexmaxi != i)
                {
                    for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++) sum += arr[i, j];
                }
                else if (indexmaxi == i) 
                {
                    for (int j = 0; j < indexmaxj; j++) sum += arr[i, j];
                }
   
            }
            Console.WriteLine($"Сумма элементов массива, расположенных между минимальным({min}) и максимальным({max}) элементами: {sum}");
        }

        static void Method3()
        {
            Console.Clear();
            var cipher = new CaesarCipher();
            Console.Write("Введите текст: ");
            var message = Console.ReadLine();
            Console.Write("Введите ключ: ");
            var secretKey = Convert.ToInt32(Console.ReadLine());
            var encryptedText = cipher.Encrypt(message, secretKey);
            Console.WriteLine($"Зашифрованное сообщение: {encryptedText}");
            Console.WriteLine($"Расшифрованное сообщение: {cipher.Decrypt(encryptedText, secretKey)}");
            Console.ReadLine();
        }

        static void Method4()
        {
            double[,] arr = new double[5, 5];
            double[,] arr1 = new double[5, 5];
            double[,] result = new double[5, 5];
            int num = 0;
            Random rand = new Random();

            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    arr[i, j] = rand.Next(1, 10);
                }
            }
            Console.WriteLine("1 матрица:");
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < arr1.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr1.Length / (arr1.GetUpperBound(0) + 1); j++)
                {
                    arr1[i, j] = rand.Next(1, 10);
                }
            }
            Console.WriteLine("2 матрица:");
            for (int i = 0; i < arr1.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr1.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    Console.Write($"{arr1[i, j]} ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("Введите число: ");
            num = Int32.Parse(Console.ReadLine());

            Console.WriteLine($"Умножение матрица 1 на {num}:");
            for (var i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    result[i, j] = arr[i, j] * num;
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Умножение матрица 2 на {num}:");
            for (var i = 0; i < arr1.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < arr1.Length / (arr1.GetUpperBound(0) + 1); j++)
                {
                    result[i, j] = arr1[i, j] * num;
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }


            Console.WriteLine("Сложение матриц 1 и 2: ");
            for (var i = 0; i < arr1.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < arr1.Length / (arr1.GetUpperBound(0) + 1); j++)
                {
                    result[i, j] = arr1[i, j] + arr[i, j];
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Произведение матриц 1 и 2: ");
            for (var i = 0; i < arr1.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < arr1.Length / (arr1.GetUpperBound(0) + 1); j++)
                {
                    result[i, j] = 0;
                    for (var k = 0; k < arr1.GetUpperBound(0) + 1; k++)
                    {
                        result[i, j] += arr[i, k] * arr1[k, j];
                    }
                }
            }

            for (int i = 0; i < result.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < result.Length / (result.GetUpperBound(0) + 1); j++)
                {
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static void Method5()
        {
            Console.Clear();
            string text;
            text = Console.ReadLine();

            DataTable table = new DataTable();
            table.Columns.Add("text", typeof(string), text);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            Console.WriteLine(double.Parse((string)row["text"]));
        }

        static void Method6()
        {
            Console.Clear();
            Console.WriteLine("Введите строку:");
            string s = Console.ReadLine();
            s = s.ToLower();
            string res = "";
            string[] res1 = s.Split(new char[] { '.','!','?' });
            foreach (string d in res1)
            {
                char[] a = d.ToCharArray();
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != ' ')
                    {
                        a[i] = char.ToUpper(a[i]);
                        break;
                    }
                }
                res = string.Concat(res, new string(a));
                res = string.Concat(res, ".");
            }
            Console.WriteLine(res);
        }
        static void Method7()
        {
            Console.Clear();
            string s = $"To be, or not to be, that is the question,\nWhether 'tis nobler in the mind to suffer\nThe slings and arrows of outrageous fortune,\nOr to take arms against a sea of troubles,\nAnd by opposing end them? To die: to sleep;\nNo more; and by a sleep to say we end\nThe heart-ache and the thousand natural shocks\nThat flesh is heir to, 'tis a consummation\nDevoutly to be wish'd. To die, to sleep.";
            Console.WriteLine($"Данн текст:\n{s}");
            Console.Write("Введите недопустимое слово: ");
            string clear = Console.ReadLine();
            Console.Write("Введите на что будет заменены недопустимые слова: ");
            string zamena = Console.ReadLine();
            s = s.Replace(clear, zamena);
            Console.WriteLine();
            Console.WriteLine("Текст после заменны: ");
            Console.WriteLine(s);
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
