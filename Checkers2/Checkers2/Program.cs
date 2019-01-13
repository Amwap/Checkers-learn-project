using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers2
{
    class Bot
    {
        public static void Bot_in_play()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board.board[i, j] == "*") { Board.board[i, j] = "@"; }
                }
            }
        }
    }
      

    class Move
    {
        public static List<Tuple<Tuple<int, int>, Tuple<int, int>>> move_list;

        //public static List<Tuple<Tuple<int, int>, Tuple<int, int>>> Lo_search()
        //{
        //    return
        //}

        public static List<Tuple<Tuple<int, int>, Tuple<int, int>>>  Move_search()
        {

            move_list = new List<Tuple<Tuple<int, int>, Tuple<int, int>>> { };
            string[] usr = User.user_move;
            Tuple<Tuple<int, int>, Tuple<int, int>> tuple;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    var Bd = Board.board;
                    
                    if (Bd[i, j] == usr[1])
                    {
                        Tuple<int, int> first = new Tuple<int, int>(i, j);
                        Tuple<int, int> last;
                        Console.WriteLine("{0} {1}",i,j);
                        try
                        {
                            if (Bd[i++, j++] != "·" && Bd[i++, j++] != usr[1])
                            {
                                if (Bd[i + 2, j + 2] == "·")
                                {
                                    last = new Tuple<int, int>(i + 2, j + 2);
                                    tuple = new Tuple<Tuple<int, int>, Tuple<int, int>>(first, last);
                                    move_list.Add(tuple);
                                    Console.WriteLine("{0} {1} {2}", i, j, first);
                                }
                            }
                        }
                        catch { }

                        try
                        {
                            if (Bd[i++, j--] != "·" && Bd[i++, j--] != usr[1])
                            {
                                if (Bd[i + 2, j - 2] == "·")
                                {
                                    last = new Tuple<int, int>(i + 2, j - 2);
                                    tuple = new Tuple<Tuple<int, int>, Tuple<int, int>>(first, last);
                                    move_list.Add(tuple);
                                    Console.WriteLine("{0} {1}", i, j);
                                }
                            }
                        }
                        catch { }

                        try
                        {
                            if (Bd[i--, j++] != "·" && Bd[i--, j++] != usr[1])
                            {
                                if (Bd[i - 2, j + 2] == "·")
                                {
                                    last = new Tuple<int, int>(i - 2, j + 2);
                                    tuple = new Tuple<Tuple<int, int>, Tuple<int, int>>(first, last);
                                    move_list.Add(tuple);
                                    Console.WriteLine("{0} {1}", i, j);
                                }
                            }
                        }
                        catch { }

                        try
                        {
                            if (Bd[i--, j--] != "·" && Bd[i--, j--] != usr[1])
                            {
                                if (Bd[i - 2, j - 2] == "·")
                                {
                                    last = new Tuple<int, int>(i - 2, j - 2);
                                    tuple = new Tuple<Tuple<int, int>, Tuple<int, int>>(first, last);
                                    move_list.Add(tuple);
                                    Console.WriteLine("{0} {1}", i, j);
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            return move_list;
        }


        public static Tuple<Tuple<int, int>, Tuple<int, int>> Translation(string coordinate)
        {

            Dictionary<char, int> transcription = new Dictionary<char, int>
            {
                ['1'] = 0,
                ['2'] = 1,
                ['3'] = 2,
                ['4'] = 3,
                ['5'] = 4,
                ['6'] = 5,
                ['7'] = 6,
                ['8'] = 7,
                ['a'] = 0,
                ['b'] = 1,
                ['c'] = 2,
                ['d'] = 3,
                ['e'] = 4,
                ['f'] = 5,
                ['g'] = 6,
                ['8'] = 7,
            };
            string movement = "";
            foreach (char letters in coordinate)
            {
                if (letters != ' ') movement += letters;
            }

            try
            {
                Convert.ToInt32(coordinate[0]);
                Tuple<int, int> first = new Tuple<int, int>(transcription[movement[1]], transcription[movement[0]]);
                Tuple<int, int> last = new Tuple<int, int>(transcription[movement[3]], transcription[movement[2]]);
                Tuple<Tuple<int, int>, Tuple<int, int>> move = new Tuple<Tuple<int, int>, Tuple<int, int>>(first, last);
                return move;
            }

            catch
            {
                try
                {
                    Tuple<int, int> first = new Tuple<int, int>(transcription[movement[0]], transcription[movement[1]]);
                    Tuple<int, int> last = new Tuple<int, int>(transcription[movement[2]], transcription[movement[3]]);
                    Tuple<Tuple<int, int>, Tuple<int, int>> move = new Tuple<Tuple<int, int>, Tuple<int, int>>(first, last);
                    return move;
                }
                catch
                {

                    Console.WriteLine("Координаты заданы неверно");
                    Tuple<int, int> unvalid = new Tuple<int, int>(0, 0);
                    Tuple<Tuple<int, int>, Tuple<int, int>> move;
                    move = new Tuple<Tuple<int, int>, Tuple<int, int>>(unvalid, unvalid);
                    return move;
                }
            }
        }
    }

    class Board
    {
        public static string[,] board = {{ "·", "o", "·", "o", "·", "o", "·", "o" },
                                         { "o", "·", "o", "·", "o", "·", "o", "·" },
                                         { "·", "o", "·", "o", "·", "o", "·", "o" },
                                         { "·", "·", "·", "·", "·", "·", "·", "·" },
                                         { "·", "·", "·", "·", "·", "·", "·", "·" },
                                         { "*", "·", "*", "·", "*", "·", "*", "·" },
                                         { "·", "*", "·", "*", "·", "*", "·", "*" },
                                         { "*", "·", "*", "·", "*", "·", "*", "·" }};

        private static void Kill(Tuple<Tuple<int, int>, Tuple<int, int>> tuple)
        {
            Tuple<int, int> first = tuple.Item1;
            Tuple<int, int> last = tuple.Item2;
            int difference = Math.Max(first.Item1, last.Item1) - Math.Min(first.Item1, last.Item1);
            if (difference == 2)
            {
                User.user_move[2] += board[Math.Min(first.Item1, last.Item1) + 1, Math.Min(first.Item2, last.Item2) + 1];
                board[Math.Min(first.Item1, last.Item1) + 1, Math.Min(first.Item2, last.Item2) + 1] = "·";
            }
        }

        public static void Movement(Tuple<Tuple<int, int>, Tuple<int, int>> tuple)
        {
            Tuple<int, int> first = tuple.Item1;
            Tuple<int, int> last = tuple.Item2;

            board[last.Item1, last.Item2] = board[first.Item1, first.Item2];
            board[first.Item1, first.Item2] = "·";
            Kill(tuple);
        }

        public static void Output()
        {
            string line;
            int l = 8;
            for (int i = 7; i >= 0; i--)
            {
                line = l.ToString() + " ";
                for (int j = 0; j < 8; j++)
                {
                    line += board[i, j] + " ";
                }

                if (i == 0) { Console.WriteLine(line + User.player1[2]); }
                else if (i == 1) { Console.WriteLine(line + "Cчёт:"); }
                else if (i == 2) { Console.WriteLine(line + User.player1[0]); }
                else if (i == 5) { Console.WriteLine(line + User.player2[2]); }
                else if (i == 6) { Console.WriteLine(line + "Счёт:"); }
                else if (i == 7) { Console.WriteLine(line + User.player2[0]); }
                else { Console.WriteLine(line); }

                l--;
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }

    class User
    {
        public static string[] player1 = { "", "o", "" };
        public static string[] player2 = { "", "*", "" };
        public static string[] user_move = player1;

        public static void Registration()
        {
            Console.Write("Первый игрок, введите имя: ");
            player1[0] = Console.ReadLine();
            //player1[0] = "Илья";

            Console.WriteLine();

            Console.Write("Второй игрок, введите имя: ");
            player2[0] = Console.ReadLine();
            //player2[0] = "Вася";

            if (player2[0] == "bot") player2[0] = "Aura"; player2[1] = "@"; Bot.Bot_in_play();
        }

        public static void Switch()
        {
            if (user_move == player1) user_move = player2;
            else if (user_move == player2) user_move = player1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User.Registration();
            Console.WriteLine();

            bool gg = true;
            while (gg)
            {
                Console.WriteLine();
                Board.Output();
                //var list = Move.Move_search();
                //if (list.Count == 0) Move.Lo_search();
                //Console.WriteLine(list.Count);
                Console.Write(User.user_move[0] + ", Ваш ход: ");
                Tuple<Tuple<int, int>, Tuple<int, int>> move = Move.Translation(Console.ReadLine());

                Board.Movement(move);
                User.Switch();
            }
        }
    }
}


