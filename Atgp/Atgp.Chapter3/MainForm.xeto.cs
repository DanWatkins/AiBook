using System;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using Atgp.Chapter3.Views;

namespace Atgp.Chapter3
{
    public partial class MainForm : Form
    {
        private readonly Board _board;
        private readonly PathPicker _pathPicker;
        private readonly TilePainter _tilePainter;

        public MainForm()
        {
            XamlReader.Load(this);

            _board = new Board(new Size(16, 12), new Size(48, 48));
            MainBoardDrawable.Board = _board;
            _pathPicker = new PathPicker(MainBoardDrawable);
            _pathPicker.PathChanged += _pathPicker_PathChanged;
            _tilePainter = new TilePainter(MainBoardDrawable);
        }

        private void PaintTilesRadioToolItem_CheckedChanged(object sender, EventArgs e)
        {
            _tilePainter.EnablePainting = PaintTilesRadioToolItem.Checked;
        }

        private void _pathPicker_PathChanged(object sender, EventArgs e)
        {
            _board.Path = _pathPicker.Path;
            MainBoardDrawable.Invalidate();
        }

        private void PickPathRadioToolItem_Click(object sender, EventArgs e)
        {
            _pathPicker.Reset();
        }
    }
}