using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki_P3
{
    internal class Ship
    {
        public int Length { get; }
        public int StartX { get; }
        public int StartY { get; }
        public bool Horizontal { get; }

        public Ship(int length, int startX, int startY, bool horizontal)
        {
            Length = length;
            StartX = startX;
            StartY = startY;
            Horizontal = horizontal;
        }
    }
}
