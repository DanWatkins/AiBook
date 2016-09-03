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
        public Color BaseColor { get; set; } = Colors.Black;

        public Color TileColor { get; set; } = Colors.Black;

        public Color GrooveColor { get; set; } = Colors.Gray;

        public Size TileSize { get; }

        public Size BoardSize { get; }

        public int GrooveThickness { get; }

        public int BorderThickness { get; }

        /// <param name="tileSize">Size of each tile in pixel units.</param>
        /// <param name="boardSize">Size of the board in tile units.</param>
        public BoardControl(Size tileSize, Size boardSize, int grooveThicknes=1, int borderThickness=1)
        {
            InitializeBoard();

            TileSize = tileSize;
            BoardSize = boardSize;
            GrooveThickness = grooveThicknes;
            BorderThickness = borderThickness;
        }

        private void InitializeBoard()
        {
            int boardWidthPx = BoardSize.Width * (TileSize.Width + GrooveThickness) - GrooveThickness;
            int boardHeightPx = BoardSize.Height * (TileSize.Height + GrooveThickness) - GrooveThickness;

            int baseWidthPx = boardWidthPx + BorderThickness * 2;
            int baseHeightPx = boardHeightPx + BorderThickness * 2;

            //update control size
            Width = baseWidthPx;
            Height = baseHeightPx;

            Paint += (sender, args) =>
            {
                var rect = new RectangleF(ClientSize);

                //draw the base
                args.Graphics.SaveTransform();
                args.Graphics.SetClip(new RectangleF(
                        0, 0,
                        baseWidthPx,
                        baseHeightPx));
                args.Graphics.FillRectangle(BaseColor, rect);

                //draw the grooves
                args.Graphics.SaveTransform();
                args.Graphics.SetClip(new RectangleF(
                        BorderThickness, BorderThickness,
                        boardWidthPx,
                        boardHeightPx));
                args.Graphics.FillRectangle(GrooveColor, rect);

                //draw the tiles
                for (int w = 0; w < BoardSize.Width; w++)
                {
                    for (int h = 0; h < BoardSize.Height; h++)
                    {
                        args.Graphics.SetClip(new RectangleF(
                                w * (TileSize.Width + GrooveThickness) + BorderThickness,
                                h * (TileSize.Height + GrooveThickness) + BorderThickness,
                                TileSize.Width,
                                TileSize.Height));
                        args.Graphics.FillRectangle(TileColor, rect);
                    }
                }

                args.Graphics.RestoreTransform();
            };
        }
    }
}