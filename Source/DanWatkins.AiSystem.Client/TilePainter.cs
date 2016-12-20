using System;
using DanWatkins.AiSystem.Client.Views;
using Eto.Drawing;
using Eto.Forms;

namespace DanWatkins.AiSystem.Client
{
    public class TilePainter
    {
        private readonly Board _board;

        public bool EnablePainting { get; set; }

        public TilePainter(Board boardView)
        {
            if (boardView == null)
                throw new ArgumentNullException(nameof(boardView));

            _board = boardView;
        }
      
        public void PaintTile(float x, float y)
        {
            if (!EnablePainting)
                return;

            var point = new Point(
                (int) (x / _board.TileSize.Width),
                (int) (y / _board.TileSize.Height));

            _board.Tiles[point.X + point.Y * _board.Size.Width] = Tile.Block;
        }
    }
}