using System;
using Eto.Forms;
using Eto.Drawing;
using Atgp.Chapter3.Controls;

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

            stackLayout.Items.Add(
                new StackLayoutItem(
                    new BoardControl(board, tileSize: new Size(64, 64)),
                    true));

            Content = stackLayout;
        }
    }
}