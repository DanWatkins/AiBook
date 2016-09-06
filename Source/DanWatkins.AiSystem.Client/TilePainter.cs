using System;
using DanWatkins.AiSystem.Client.Views;
using Eto.Drawing;
using Eto.Forms;

namespace DanWatkins.AiSystem.Client
{
    public class TilePainter
    {
        private readonly BoardDrawable _boardControl;

        public TilePainter(BoardDrawable boardControl)
        {
            if (boardControl == null)
                throw new ArgumentNullException(nameof(boardControl));

            _boardControl = boardControl;
        }

        private bool _enablePainting = false;
        public bool EnablePainting
        {
            get { return _enablePainting; }
            set
            {
                if (_enablePainting == value)
                    return;

                if (value)
                    _boardControl.MouseDown += BoardControl_MouseDown;
                else
                    _boardControl.MouseDown -= BoardControl_MouseDown;

                _enablePainting = value;
            }
        }

        private void BoardControl_MouseDown(object sender, MouseEventArgs e)
        {
            var point = new Point(
                (int) (e.Location.X / _boardControl.Board.TileSize.Width),
                (int) (e.Location.Y / _boardControl.Board.TileSize.Height));

            _boardControl.Board.Tiles[point.X + point.Y * _boardControl.Board.Size.Width] = Tile.Block;
            _boardControl.Invalidate();
        }
    }
}