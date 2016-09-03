using Atgp.Chapter3.Controls;
using Eto.Drawing;
using Eto.Forms;
using System;

namespace Atgp.Chapter3
{
    public class MainForm : Form
    {
        private readonly Board _board;
        private readonly BoardControl _boardControl;
        private readonly PathPicker _pathPicker;
        private readonly TilePainter _tilePainter;

        public MainForm()
        {
            Title = "Genetic Pathfinder";
            ClientSize = new Size(1280, 720);

            _board = new Board(new Size(16, 12), new Size(48, 48));

            _boardControl = new BoardControl(_board );
            _pathPicker = new PathPicker(_boardControl);
            _pathPicker.PathChanged += _pathPicker_PathChanged;
            _tilePainter = new TilePainter(_boardControl);

            var controlStackLayout = new StackLayout
            {
                Orientation = Orientation.Vertical
            };

            var pickPathButton = new Button
            {
                Text = "Pick Path"
            };
            pickPathButton.Click += PickPathButton_Click;

            controlStackLayout.Items.Add(new StackLayoutItem(pickPathButton));

            var panel = new Panel
            {
                Width = 300,
                Content = new GroupBox
                {
                    Text = "Control",
                    Content = controlStackLayout
                }
            };

            Content = new Splitter
            {
                Orientation = Orientation.Horizontal,
                Panel1 = panel,
                Panel2 = _boardControl
            };
        }

        private void _pathPicker_PathChanged(object sender, EventArgs e)
        {
            _board.Path = _pathPicker.Path;
            _boardControl.Invalidate();
        }

        private void PickPathButton_Click(object sender, EventArgs e)
        {
            _pathPicker.Reset();
        }
    }
}