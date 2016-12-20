using DanWatkins.AiSystem.Client.Views;
using Eto.Drawing;
using System;
using System.Collections.Generic;
using Eto.Forms;

namespace DanWatkins.AiSystem.Client
{
    public class PathPicker
    {
        private PointF? _start;
        private PointF? _finish;
        private readonly BoardView _boardView;

        public Path Path { get; private set; }

        public event EventHandler PathChanged;

        public PathPicker(BoardView boardView)
        {
            if (boardView == null)
                throw new ArgumentNullException(nameof(boardView));

            _boardView = boardView;
        }

        public void Start()
        {
            _start = null;
            _finish = null;

            BuildPath();

            _boardView.MouseDown += BoardControl_MouseDown;
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

            Path = new Path(list);
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