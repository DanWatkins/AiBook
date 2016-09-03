using Eto.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atgp.Chapter3
{
    public class Board
    {
        public Size Size { get; }

        public Path Path { get; set; }

        public Board(Size boardSize)
        {
            Size = boardSize;
        }
    }
}