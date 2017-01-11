using Eto.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace DanWatkins.AiSystem.Model
{
    public class Board
    {
        public Size Size { get; }

        public Size TileSize { get; }

        public int GrooveThickness { get; }

        public int BorderThickness { get; }

        public Path Path { get; set; }

        public List<Tile> Tiles { get; }

        public Board(Size boardSize, Size tileSize, int grooveThicknes = 1, int borderThickness = 1)
        {
            Size = boardSize;
            TileSize = tileSize;
            GrooveThickness = grooveThicknes;
            BorderThickness = borderThickness;

            Tiles = Enumerable.Repeat(Tile.Ground, Size.Width * Size.Height).ToList();
        }
    }
}