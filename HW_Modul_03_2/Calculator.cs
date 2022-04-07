using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_03_2
{
    internal class Calculator
    {
        public string _number;
        public int _fromSystem;
        public int _toSystem;
        char[] SOC = { '0','1','2','3','4','5','6','7','8','9','A','B','C',
                'D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T',
            'U','V','W','X','Y','Z' };
        public Calculator(string number, int fromSystem, int toSystem)
        {
            try
            {
                _number = number;
                _fromSystem = fromSystem;
                _toSystem = toSystem;

                if (fromSystem <= 1 || toSystem <= 1 || fromSystem >= 37 || toSystem >= 37)
                    throw new Exception("Такой системы счисления нет");

                for (int i = 0; i < _number.Length; i++)
                {
                    for (int j = 0; j < SOC.Length; j++)
                    {
                        if (_number[i] == SOC[j] && SOC[j] > SOC[fromSystem - 1])
                            throw new Exception("Выход за пределы системы счисления");

                    }
                }

                WriteLine($"{_number} в {_fromSystem} = { Convert(_number, _fromSystem, _toSystem)} в {_toSystem}");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        private string Convert(string number, int fromBase, int toBase)
        {
            number.ToLower();
            string res = "";
            int dec = 0;
            string SOC = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < number.Length; i++)
            {
                int chislo = SOC.IndexOf(number[i]);
                dec += chislo * (int)Math.Pow(fromBase, number.Length - i - 1);
            }

            while (dec >= toBase)
            {
                int ost = dec % toBase;
                res = res.Insert(0, SOC[ost].ToString());
                dec /= toBase;
            }
            res = res.Insert(0, SOC[dec].ToString());
            return res;
        }
    }
}
