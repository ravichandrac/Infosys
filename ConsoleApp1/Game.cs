using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Pastel;
using Figgle;

namespace ConsoleApp1
{
    class Game
    {
        private Maze MyMaze;
        private Player CurrentPlayer;
        private List<string> PathTaken;
        private int X;
        private int Y;
        public void Start()
        {
            //WriteLine("Game is Starting");
            Title = "Maze";
            CursorVisible = false;

            string[,] grid = MazeFileParser.ParserFiletoStringArray("Maze.txt");

            MyMaze = new Maze(grid);
            MyMaze.Draw();
            WriteLine();

            CurrentPlayer = new Player(3, 3);
            CurrentPlayer.Draw();

            //WriteLine("Press any key to exit");
            RunGameLoop();
        }

        private void DisplayIntro()
        {
            Clear();
            WriteLine(FiggleFonts.Larry3d.Render("Welcome to the Maze!"));
            WriteLine("Press any key to start");
            ReadKey();
        }

        private void DisplayExit()
        {
            Clear();
            WriteLine(FiggleFonts.Larry3d.Render("Game Over!"));
            ReadKey();
        }

        private void DrawFrame()
        {
            Clear();
            MyMaze.Draw();
            CurrentPlayer.Draw();
        }

        private void HandleMenu()
        {
            SetCursorPosition(X, Y);
            foreach(string str1 in PathTaken)
            {
                 Write(str1);
            }
            ConsoleKey key;
            ConsoleKeyInfo keyInfo = ReadKey(true);
            key = keyInfo.Key;

            string str = "";
            if (key == ConsoleKey.O)
            {
                SetCursorPosition(75, 15);
                WriteLine("Enter coords");
                keyInfo = ReadKey(true);
                key = keyInfo.Key;

                str = Console.ReadLine();
                string elementatcoord = MyMaze.GetElementAt(int.Parse(str.Split(',')[0]), int.Parse(str.Split(',')[1]));
                WriteLine(elementatcoord == " " ? " Empty Space " : elementatcoord);
                Task.Delay(30000);
            }

        }

            private void HandlePlayerInput()
        {
            SetCursorPosition(75, 10);
            string options = "";
            if (MyMaze.IsCoordinateMovable(CurrentPlayer.X, CurrentPlayer.Y - 1))
            {
                options += " Up ";
            }
            if (MyMaze.IsCoordinateMovable(CurrentPlayer.X, CurrentPlayer.Y + 1))
            {
                options += " Down ";
            }
            if (MyMaze.IsCoordinateMovable(CurrentPlayer.X - 1, CurrentPlayer.Y))
            {
                options += " Left ";
            }
            if (MyMaze.IsCoordinateMovable(CurrentPlayer.X + 1, CurrentPlayer.Y))
            {
                options += " Right ";
            }
            WriteLine(options);

            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;

            } while (KeyAvailable);

            //string str = "";
            //if(key == ConsoleKey.O)
            //{
            //        SetCursorPosition(75, 15);
            //        WriteLine("Enter coords");
            //        ConsoleKeyInfo keyInfo = ReadKey(true);
            //        key = keyInfo.Key;

            //        str = Console.ReadLine();
            //        string elementatcoord = MyMaze.GetElementAt(int.Parse(str.Split(',')[0]), int.Parse(str.Split(',')[1]));
            //        WriteLine(elementatcoord == " " ? " Empty Space " : elementatcoord);
            //}

            
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyMaze.IsCoordinateMovable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                        if(!PathTaken.Contains("(" + CurrentPlayer.X + "," + CurrentPlayer.Y + ") " ))
                            PathTaken.Add("(" + CurrentPlayer.X + "," + CurrentPlayer.Y + ") ");
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyMaze.IsCoordinateMovable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {   
                        CurrentPlayer.Y += 1;
                        if (!PathTaken.Contains("(" + CurrentPlayer.X + "," + CurrentPlayer.Y + ") "))
                            PathTaken.Add("(" + CurrentPlayer.X + "," + CurrentPlayer.Y + ") ");
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyMaze.IsCoordinateMovable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {   
                        CurrentPlayer.X -= 1;
                        if (!PathTaken.Contains("(" + CurrentPlayer.X + "," + CurrentPlayer.Y + ") ")) 
                            PathTaken.Add("(" + CurrentPlayer.X + "," + CurrentPlayer.Y + ") ");
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyMaze.IsCoordinateMovable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {   
                        CurrentPlayer.X += 1;
                        if (!PathTaken.Contains("(" + CurrentPlayer.X + "," + CurrentPlayer.Y + ") ")) 
                            PathTaken.Add("(" + CurrentPlayer.X + "," + CurrentPlayer.Y + ") ");
                    }
                    break;
                default:
                    break;
            }
            
        }
        private void RunGameLoop()
        {
            PathTaken = new List<string>();
            PathTaken.Add("Route : ");
            X = 50; Y = 20;
            DisplayIntro();

            while (true)
            {
                DrawFrame();
                HandlePlayerInput();
                HandleMenu();
                string elementAtPlayerPosition = MyMaze.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPosition == "F")
                {
                    break;
                }
                System.Threading.Thread.Sleep(20);

            }
            DisplayExit();
        }
    }
}
