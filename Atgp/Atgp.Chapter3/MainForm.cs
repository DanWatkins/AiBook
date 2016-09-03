using System;
using Eto.Forms;
using Eto.Drawing;
using Atgp.Chapter3.Controls;
using System.Collections.Generic;

namespace Atgp.Chapter3
{
    public class MainForm : Form
    {
        public MainForm()
        {
            Title = "Genetic Pathfinder";
            ClientSize = new Size(1280, 720);

            var stackLayout = new StackLayout
            {
                HorizontalContentAlignment = HorizontalAlignment.Stretch
            };

            var board = new Board(new Size(16, 8));
            board.Path = new Path(new List<Point>
            {
                new Point(0,1),
                new Point(0,2),
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(1,5),
                new Point(2,5),
                new Point(3,5)
            });

            stackLayout.Items.Add(
                new StackLayoutItem(
                    new BoardControl(board, tileSize: new Size(64, 64)),
                    true));

            Content = stackLayout;
        }
    }
}