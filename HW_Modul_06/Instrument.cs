using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_06
{
    internal class Instrument
    {
        public string Name { get; set; }
        public string Specifications { get; set; }
        public void Print()
        {
            WriteLine($"Название: {Name}\n Хар-ка: {Specifications}");
        }
    }

    class Violin : Instrument
    {
        public Violin(string name, string har)
        {
            Name = name;
            Specifications = har;
        }
        public void Sound()
        {
            WriteLine("Звук скрипки");
        }
        public void Show()
        {
            WriteLine($"Название инструмента: {Name}");
        }
        public void Desc()
        {
            WriteLine($"Описание инструмента: {Specifications}");
        }
        public void History()
        {
            string History = ReadLine();
            WriteLine($"История иструмента: {History}");
        }
    }
    class Trombone : Instrument
    {
        public Trombone(string name, string har)
        {
            Name = name;
            Specifications = har;
        }
        public void Sound()
        {
            WriteLine("Звук тромбона");
        }
        public void Show()
        {
            WriteLine($"Название инструмента: {Name}");
        }
        public void Desc()
        {
            WriteLine($"Описание инструмента: {Specifications}");
        }
        public void History()
        {
            string History = ReadLine();
            WriteLine($"История иструмента: {History}");
        }
    }
    class Ukulele : Instrument
    {
        public Ukulele(string name, string har)
        {
            Name = name;
            Specifications = har;
        }
        public void Sound()
        {
            WriteLine("Звук укулеле");
        }
        public void Show()
        {
            WriteLine($"Название инструмента: {Name}");
        }
        public void Desc()
        {
            WriteLine($"Описание инструмента: {Specifications}");
        }
        public void History()
        {
            string History = ReadLine();
            WriteLine($"История иструмента: {History}");
        }
    }
    class Cello : Instrument
    {
        public Cello(string name, string har)
        {
            Name = name;
            Specifications = har;
        }
        public void Sound()
        {
            WriteLine("Звук виолончели");
        }
        public void Show()
        {
            WriteLine($"Название инструмента: {Name}");
        }
        public void Desc()
        {
            WriteLine($"Описание инструмента: {Specifications}");
        }
        public void History()
        {
            string History = ReadLine();
            WriteLine($"История иструмента: {History}");
        }
    }
}
