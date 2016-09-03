using Eto.Drawing;

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