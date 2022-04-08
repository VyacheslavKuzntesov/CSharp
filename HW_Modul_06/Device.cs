using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_06
{
    internal class Device
    {
        protected string Name;
        protected string Specifications;

        public Device(string name, string specification)
        {
            Name = name;
            Specifications = specification;
        }

        public override string ToString()
        {
            return ($"Название устройства: {Name}\n" +
                $"Характеристика: {Specifications}");
        }
    }

    class Teapot : Device
    {
        public Teapot(string name, string specification) : base(name, specification)
        {
            Name = name;
            Specifications = specification;
        }
        public void Sound()
        {
            WriteLine("Cвист чайника");
        }
        public void Show()
        {
            WriteLine($"Название устройства: {Name}");
        }
        public void Desc()
        {
            WriteLine($"Характеристика устройства: {Specifications}");
        }
    }

    class Microwave : Device
    {
        public Microwave(string name, string specification) : base(name, specification)
        {
            Name = name;
            Specifications = specification;
        }
        public void Sound()
        {
            WriteLine("Звуки микроволновки");
        }
        public void Show()
        {
            WriteLine($"Название устройства: {Name}");

        }
        public void Desc()
        {
            WriteLine($"Характеристика устройства: {Specifications}");

        }
    }

    class Avto : Device
    {
        public Avto(string name, string specification) : base(name, specification)
        {
            Name = name;
            Specifications = specification;
        }
        public void Sound()
        {
            WriteLine("Звуки машины");
        }
        public void Show()
        {
            WriteLine($"Название устройства: {Name}");

        }
        public void Desc()
        {
            WriteLine($"Характеристика устройства: {Specifications}");

        }
    }

    class Boat : Device
    {
        public Boat(string name, string specification) : base(name, specification)
        {
            Name = name;
            Specifications = specification;
        }
        public void Sound()
        {
            WriteLine($"Звук парохода");
        }
        public void Show()
        {
            WriteLine($"Название устройства: {Name}");

        }
        public void Desc()
        {
            WriteLine($"Характеристика устройства: {Specifications}");

        }
    }
}
