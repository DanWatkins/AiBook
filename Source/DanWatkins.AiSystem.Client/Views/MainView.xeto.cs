using System;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;

namespace DanWatkins.AiSystem.Client.Views
{
    public partial class MainView : Form
    {
        private readonly Board _board;
        private readonly PathPicker _pathPicker;
        private readonly TilePainter _tilePainter;

        public MainView()
        {
            XamlReader.Load(this);

            _board = new Board(new Size(16, 12), new Size(48, 48));
            MainBoardView.Board = _board;
            MainBoardView.MouseDown += MainBoardView_MouseDown;
            _pathPicker = new PathPicker(MainBoardView);
            _pathPicker.PathChanged += _pathPicker_PathChanged;
            _tilePainter = new TilePainter(_board);
        }

        private void MainBoardView_MouseDown(object sender, MouseEventArgs e)
        {
            _tilePainter.PaintTile(e.Location.X, e.Location.Y);
            MainBoardView.Invalidate();
        }

        private void PaintTilesRadioToolItem_Click(object sender, EventArgs e)
        {
            _tilePainter.EnablePainting = PaintTilesRadioToolItem.Checked;
        }

        private void _pathPicker_PathChanged(object sender, EventArgs e)
        {
            _board.Path = _pathPicker.Path;
            MainBoardView.Invalidate();
        }

        private void PickPathRadioToolItem_Click(object sender, EventArgs e)
        {
            _pathPicker.Start();
        }
    }
}