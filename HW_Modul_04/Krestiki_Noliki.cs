using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Modul_04
{
    internal class Krestiki_Noliki
    {
        Dictionary<int, List<int>> AuthorDict = new Dictionary<int, List<int>>()
        {
            {1, new List<int>() { 2,0}},
            {2, new List<int>() { 2,1}},
            {3, new List<int>() { 2,2}},
            {4, new List<int>() { 1,0}},
            {5, new List<int>() { 1,1}},
            {6, new List<int>() { 1,2}},
            {7, new List<int>() { 0,0}},
            {8, new List<int>() { 0,1}},
            {9, new List<int>() { 0,2}},
        };


        private char[,] _field = new char[3, 3]
       {
            { ' ',' ',' ' },
            { ' ',' ',' ' },
            { ' ',' ',' ' },
       };
        private bool _isXMove = true;

        public Krestiki_Noliki()
        {
            WriteLine("1 - 1игрок vs 2игрок\n2 - игрок vs компьютера ");
            int v = Int32.Parse(ReadLine());
            Draw();
            int cell;
            switch (v)
            {
                case 1:
                    do
                    {
                        Write("Введите номер клетки: "); cell = int.Parse(ReadLine());

                        Update(cell);
                        Draw();
                    } while (true);


                    break;
                case 2:
                    Random rand = new Random();
                    int player = rand.Next(1, 3);
                    if (player == 1)
                    {
                        WriteLine("\nПервым ходит игрок");
                        do
                        {
                            Write("Введите номер клетки: "); cell = int.Parse(ReadLine());

                            Player_1(cell);
                            Draw();


                        } while (true);
                    }
                    if (player == 2)
                    {
                        do
                        {
                            Computer1();
                            Draw();

                            Player_2();
                            Draw();
                        } while (true);
                    }

                    break;
            }
        }
        private void Draw()
        {
            Clear();

            WriteLine();
            WriteLine(string.Format(" {0} | {1} | {2} ", _field[0, 0], _field[0, 1], _field[0, 2]));
            WriteLine("---+---+---");
            WriteLine(string.Format(" {0} | {1} | {2} ", _field[1, 0], _field[1, 1], _field[1, 2]));
            WriteLine("---+---+---");
            WriteLine(string.Format(" {0} | {1} | {2} ", _field[2, 0], _field[2, 1], _field[2, 2]));

        }
        private void Update(int cell)
        {
            if (1 <= cell && cell <= 9)
            {
                if (_field[AuthorDict[cell][0], AuthorDict[cell][1]] == ' ')
                {
                    _field[AuthorDict[cell][0], AuthorDict[cell][1]] = _isXMove ? 'X' : 'O';
                    if (IsWinner('X'))
                    {
                        Draw();
                        EndGame("Крестики");
                    }
                    else if (IsWinner('O'))
                    {
                        Draw();
                        EndGame("Нолики");
                    }
                    else if (_field[0, 0] != ' ' && _field[0, 1] != ' ' && _field[0, 2] != ' '
                         && _field[1, 0] != ' ' && _field[1, 1] != ' ' && _field[1, 2] != ' '
                         && _field[2, 0] != ' ' && _field[2, 1] != ' ' && _field[2, 2] != ' ')
                    {
                        Draw();
                        EndGame1("Ничья");
                    }

                    _isXMove = !_isXMove;
                }
                else WriteLine("Клетка занята!");
            }
        }
        private void Player_1(int cell)
        {
            if (1 <= cell && cell <= 9 )
            {
                if (_field[AuthorDict[cell][0], AuthorDict[cell][1]] == ' ')
                {
                    _field[AuthorDict[cell][0], AuthorDict[cell][1]] = 'X';
                }
                else WriteLine("Клетка занята!");

                Computer();
                Draw();
                Proverka();
            }
        }
        private void Player_2()
        {

            Proverka();
            int cell;
            WriteLine("\nПервым ходит компьютер");

            Write("Введите номер клетки: "); cell = int.Parse(ReadLine());

            if (1 <= cell && cell <= 9)
            {

                if (_field[AuthorDict[cell][0], AuthorDict[cell][1]] == ' ')
                {
                    _field[AuthorDict[cell][0], AuthorDict[cell][1]] = 'O';
                }
                else WriteLine("Клетка занята!");
            }
            Proverka();
        }
        private void Proverka()
        {
            if (IsWinner('X'))
            {
                Draw();
                EndGame("Крестики");
            }
            else if (IsWinner('O'))
            {
                Draw();
                EndGame("Нолики");
            }
            else if (_field[0, 0] != ' ' && _field[0, 1] != ' ' && _field[0, 2] != ' '
                         && _field[1, 0] != ' ' && _field[1, 1] != ' ' && _field[1, 2] != ' '
                         && _field[2, 0] != ' ' && _field[2, 1] != ' ' && _field[2, 2] != ' ')
            {
                Draw();
                EndGame1("Ничья");
            }
        }
        private void Computer()
        {
            bool hod = false;
            if (_field[1, 1] == ' ') { _field[1, 1] = 'O'; hod = true; }
            if (hod == false)
            { if (_field[0, 0] == ' ') { _field[0, 0] = 'O'; hod = true; } }

            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[0, 1] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[0, 2] == 'O' && _field[0, 1] == ' ')
                { _field[0, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'O' && _field[0, 2] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[1, 0] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[2, 0] == 'O' && _field[1, 0] == ' ')
                { _field[1, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 0] == 'O' && _field[2, 0] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[2, 1] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[2, 2] == 'O' && _field[2, 1] == ' ')
                { _field[2, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'O' && _field[2, 2] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[1, 2] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[0, 2] == 'O' && _field[1, 2] == ' ')
                { _field[1, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'O' && _field[0, 2] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[1, 1] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[1, 1] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 2] == 'O' && _field[1, 1] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[1, 1] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[1, 0] == 'O' && _field[1, 1] == 'O' && _field[1, 2] == ' ')
                { _field[1, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'O' && _field[1, 1] == 'O' && _field[1, 0] == ' ')
                { _field[1, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'O' && _field[1, 1] == 'O' && _field[2, 1] == ' ')
                { _field[2, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'O' && _field[1, 1] == 'O' && _field[0, 1] == ' ')
                { _field[0, 1] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[0, 1] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[0, 2] == 'X' && _field[0, 1] == ' ')
                { _field[0, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'X' && _field[0, 2] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[1, 0] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[2, 0] == 'X' && _field[1, 0] == ' ')
                { _field[1, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 0] == 'X' && _field[2, 0] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[2, 1] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[2, 2] == 'X' && _field[2, 1] == ' ')
                { _field[2, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'X' && _field[2, 2] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[1, 2] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[0, 2] == 'X' && _field[1, 2] == ' ')
                { _field[1, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'X' && _field[0, 2] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[1, 1] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[1, 1] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 2] == 'X' && _field[1, 1] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[1, 1] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'O'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[1, 0] == 'X' && _field[1, 1] == 'X' && _field[1, 2] == ' ')
                { _field[1, 2] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'X' && _field[1, 1] == 'X' && _field[1, 0] == ' ')
                { _field[1, 0] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'X' && _field[1, 1] == 'X' && _field[2, 1] == ' ')
                { _field[2, 1] = 'O'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'X' && _field[1, 1] == 'X' && _field[0, 1] == ' ')
                { _field[0, 1] = 'O'; hod = true; }
            }


            if (hod == false)
            { if (_field[2, 2] == ' ') { _field[2, 2] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[0, 2] == ' ') { _field[0, 2] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[2, 0] == ' ') { _field[2, 0] = 'O'; hod = true; } }

            if (hod == false)
            { if (_field[2, 1] == ' ') { _field[2, 1] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[0, 1] == ' ') { _field[0, 1] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[1, 0] == ' ') { _field[1, 0] = 'O'; hod = true; } }
            if (hod == false)
            { if (_field[1, 2] == ' ') { _field[1, 2] = 'O'; hod = true; } }

        }
        private void Computer1()
        {
            bool hod = false;
            if (_field[1, 1] == ' ') { _field[1, 1] = 'X'; hod = true; }
            if (hod == false)
            { if (_field[0, 0] == ' ') { _field[0, 0] = 'X'; hod = true; } }

            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[0, 1] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[0, 2] == 'X' && _field[0, 1] == ' ')
                { _field[0, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'X' && _field[0, 2] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[1, 0] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[2, 0] == 'X' && _field[1, 0] == ' ')
                { _field[1, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 0] == 'X' && _field[2, 0] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[2, 1] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[2, 2] == 'X' && _field[2, 1] == ' ')
                { _field[2, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'X' && _field[2, 2] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[1, 2] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[0, 2] == 'X' && _field[1, 2] == ' ')
                { _field[1, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'X' && _field[0, 2] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'X' && _field[1, 1] == 'X' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'X' && _field[1, 1] == 'X' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 2] == 'X' && _field[1, 1] == 'X' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'X' && _field[1, 1] == 'X' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[1, 0] == 'X' && _field[1, 1] == 'X' && _field[1, 2] == ' ')
                { _field[1, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'X' && _field[1, 1] == 'X' && _field[1, 0] == ' ')
                { _field[1, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'X' && _field[1, 1] == 'X' && _field[2, 1] == ' ')
                { _field[2, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'X' && _field[1, 1] == 'X' && _field[0, 1] == ' ')
                { _field[0, 1] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[0, 1] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[0, 2] == 'O' && _field[0, 1] == ' ')
                { _field[0, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'O' && _field[0, 2] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[1, 0] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[2, 0] == 'O' && _field[1, 0] == ' ')
                { _field[1, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 0] == 'O' && _field[2, 0] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[2, 1] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[2, 2] == 'O' && _field[2, 1] == ' ')
                { _field[2, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'O' && _field[2, 2] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[1, 2] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[0, 2] == 'O' && _field[1, 2] == ' ')
                { _field[1, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'O' && _field[0, 2] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[0, 0] == 'O' && _field[1, 1] == 'O' && _field[2, 2] == ' ')
                { _field[2, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 2] == 'O' && _field[1, 1] == 'O' && _field[0, 0] == ' ')
                { _field[0, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 2] == 'O' && _field[1, 1] == 'O' && _field[2, 0] == ' ')
                { _field[2, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 0] == 'O' && _field[1, 1] == 'O' && _field[0, 2] == ' ')
                { _field[0, 2] = 'X'; hod = true; }
            }

            if (hod == false)
            {
                if (_field[1, 0] == 'O' && _field[1, 1] == 'O' && _field[1, 2] == ' ')
                { _field[1, 2] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[1, 2] == 'O' && _field[1, 1] == 'O' && _field[1, 0] == ' ')
                { _field[1, 0] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[0, 1] == 'O' && _field[1, 1] == 'O' && _field[2, 1] == ' ')
                { _field[2, 1] = 'X'; hod = true; }
            }
            if (hod == false)
            {
                if (_field[2, 1] == 'O' && _field[1, 1] == 'O' && _field[0, 1] == ' ')
                { _field[0, 1] = 'X'; hod = true; }
            }


            if (hod == false)
            { if (_field[2, 2] == ' ') { _field[2, 2] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[0, 2] == ' ') { _field[0, 2] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[2, 0] == ' ') { _field[2, 0] = 'X'; hod = true; } }

            if (hod == false)
            { if (_field[2, 1] == ' ') { _field[2, 1] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[0, 1] == ' ') { _field[0, 1] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[1, 0] == ' ') { _field[1, 0] = 'X'; hod = true; } }
            if (hod == false)
            { if (_field[1, 2] == ' ') { _field[1, 2] = 'X'; hod = true; } }

        }

        private bool IsWinner(char player)
        {
            return
                (

                (_field[0, 0] == player && _field[0, 1] == player && _field[0, 2] == player) ||
                (_field[1, 0] == player && _field[1, 1] == player && _field[1, 2] == player) ||
                (_field[2, 0] == player && _field[2, 1] == player && _field[2, 2] == player) ||

                (_field[0, 0] == player && _field[1, 0] == player && _field[2, 0] == player) ||
                (_field[0, 1] == player && _field[1, 1] == player && _field[2, 1] == player) ||
                (_field[0, 2] == player && _field[1, 2] == player && _field[2, 2] == player) ||

                (_field[0, 0] == player && _field[1, 1] == player && _field[2, 2] == player) ||
                (_field[0, 2] == player && _field[1, 1] == player && _field[2, 0] == player)
                );
        }
        private void EndGame(string player)
        {
            WriteLine($"Победили {player}!");
            ReadKey();
            ClearField();
        }
        private void EndGame1(string player)
        {
            WriteLine($"Ничья!");
            ReadKey();
            ClearField();
        }

        private void ClearField()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _field[i, j] = ' ';
                }
            }
        }
    }
}
