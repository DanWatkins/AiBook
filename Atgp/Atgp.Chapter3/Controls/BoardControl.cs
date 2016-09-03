using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atgp.Chapter3.Controls
{
    public class BoardControl : Drawable
    {
        private readonly Board _board;

        public Color BaseColor { get; set; } = Colors.Black;

        public Color TileColor { get; set; } = Colors.Black;

        public Color GrooveColor { get; set; } = Colors.Gray;

        public Size TileSize { get; }

        public int GrooveThickness { get; }

        public int BorderThickness { get; }

        /// <param name="tileSize">Size of each tile in pixel units.</param>
        /// <param name="boardSize">Size of the board in tile units.</param>
        public BoardControl(Board board, Size tileSize, int grooveThicknes = 1, int borderThickness = 1)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            _board = board;

            TileSize = tileSize;
            GrooveThickness = grooveThicknes;
            BorderThickness = borderThickness;

            Paint += BoardControl_Paint;
        }

        private void BoardControl_Paint(object sender, PaintEventArgs args)
        {
            int boardWidthPx = _board.Size.Width * (TileSize.Width + GrooveThickness) - GrooveThickness;
            int boardHeightPx = _board.Size.Height * (TileSize.Height + GrooveThickness) - GrooveThickness;

            int baseWidthPx = boardWidthPx + BorderThickness * 2;
            int baseHeightPx = boardHeightPx + BorderThickness * 2;

            Width = baseWidthPx;
            Height = baseHeightPx;

            var rect = new RectangleF(ClientSize);

            // draw the base
            args.Graphics.SaveTransform();
            args.Graphics.SetClip(new RectangleF(
                    0, 0,
                    baseWidthPx,
                    baseHeightPx));
            args.Graphics.FillRectangle(BaseColor, rect);

            // draw the grooves
            args.Graphics.SaveTransform();
            args.Graphics.SetClip(new RectangleF(
                    BorderThickness, BorderThickness,
                    boardWidthPx,
                    boardHeightPx));
            args.Graphics.FillRectangle(GrooveColor, rect);

            // draw the tiles
            for (int x = 0; x < _board.Size.Width; x++)
            {
                for (int y = 0; y < _board.Size.Height; y++)
                {
                    args.Graphics.SetClip(new RectangleF(
                            x * (TileSize.Width + GrooveThickness) + BorderThickness,
                            y * (TileSize.Height + GrooveThickness) + BorderThickness,
                            TileSize.Width,
                            TileSize.Height));
                    args.Graphics.FillRectangle(TileColor, rect);
                }
            }

            // draw the path
            if (_board.Path != null)
            {
                foreach (var part in _board.Path.Parts)
                {
                    double scale = 0.55;
                    int centeringX = (int)(TileSize.Width * scale);
                    int centeringY = (int)(TileSize.Height * scale);

                    args.Graphics.SetClip(new RectangleF(
                            part.X * (TileSize.Width + GrooveThickness) + BorderThickness + centeringX,
                            part.Y * (TileSize.Height + GrooveThickness) + BorderThickness + centeringY,
                            TileSize.Width - 2 * centeringX,
                            TileSize.Height - 2 * centeringY));

                    if (part == _board.Path.Parts.First())
                        args.Graphics.FillRectangle(Colors.LightGreen, rect);
                    else if (part == _board.Path.Parts.Last())
                        args.Graphics.FillRectangle(Colors.Red, rect);
                    else
                        args.Graphics.FillRectangle(Colors.LightSlateGray, rect);
                }
            }

            args.Graphics.RestoreTransform();
        }
    }
}