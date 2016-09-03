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

        private readonly RadioToolItem _pickPathButton;
        private readonly RadioToolItem _paintTilesButton;

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

            _pickPathButton = new RadioToolItem
            {
                Text = "Pick Path"
            };
            _pickPathButton.Click += PickPathButton_Click;

            _paintTilesButton = new RadioToolItem
            {
                Text = "Paint Tiles"
            };
            _paintTilesButton.CheckedChanged += _paintTilesButton_CheckedChanged;

            var toolBar = new ToolBar
            {
                Items =
                {
                    _pickPathButton,
                    _paintTilesButton
                }
            };

            ToolBar = toolBar;
            Content = _boardControl;
        }

        private void _paintTilesButton_CheckedChanged(object sender, EventArgs e)
        {
            _tilePainter.EnablePainting = _paintTilesButton.Checked;
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