using DanWatkins.AiSystem.Client.Views;
using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanWatkins.AiSystem.Client.ViewModels
{
    public class MainViewModel
    {
        private bool _isPicking = false;
        private PointF? _start;
        private PointF? _finish;
        private readonly BoardView _boardView;

        public Board Board { get; }

        public bool EnablePainting { get; set; }

        public Path CurrentPath { get; private set; }

        public event EventHandler PathChanged;

        public bool IsPicking
        {
            get
            {
                return _isPicking;
            }
            set
            {
                if (value == _isPicking) return;

                _start = null;
                _finish = null;

                BuildPath();

                _boardView.MouseDown += BoardControl_MouseDown;
            }
        }

        public MainViewModel(Board board, BoardView boardView)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            if (boardView == null)
                throw new ArgumentNullException(nameof(boardView));

            _boardView = boardView;
            Board = board;
        }

        public void PaintTile(float x, float y)
        {
            if (!EnablePainting)
                return;

            var point = new Point(
                (int)(x / Board.TileSize.Width),
                (int)(y / Board.TileSize.Height));

            Board.Tiles[point.X + point.Y * Board.Size.Width] = Tile.Block;
        }

        private void BuildPath()
        {
            var list = new List<Point>();

            Action<PointF?> tryAdd = (point) =>
            {
                if (point == null) return;

                list.Add(new Point(
                    (int)(point.Value.X / _boardView.Board.TileSize.Width),
                    (int)(point.Value.Y / _boardView.Board.TileSize.Height)));
            };

            tryAdd(_start);
            tryAdd(_finish);

            CurrentPath = new Path(list);
            Board.Path = CurrentPath;
            PathChanged?.Invoke(this, EventArgs.Empty);
        }

        private void BoardControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (_start == null)
                _start = e.Location;
            else if (_finish == null)
            {
                _finish = e.Location;
                _boardView.MouseDown -= BoardControl_MouseDown;
            }

            BuildPath();
        }
    }
}