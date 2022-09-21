using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    class Stats
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private ConsoleColor PlayerColor;
        public Stats(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "®";
            PlayerColor = ConsoleColor.Red;
        }

        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarker);
            ResetColor();

        }
    }
}
