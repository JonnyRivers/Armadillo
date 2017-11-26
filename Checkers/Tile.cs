using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Checkers
{
    public class Tile
    {
        public Tile(int x, int y, Brush fill)
        {
            X = x;
            Y = y;
            Fill = fill;
        }

        public int X { get; set; }
        public int Y { get; }
        public Brush Fill { get; }
    }
}
