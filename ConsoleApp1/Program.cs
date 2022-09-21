using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    class RatMaze
    {
        
        public static void Main(String[] args)
        {
            Game currentGame = new Game();
            currentGame.Start();
        }
    }
}
