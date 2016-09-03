using Atgp.Chapter3.Controls;
using Eto.Drawing;
using System;
using System.Collections.Generic;
using Eto.Forms;

namespace Atgp.Chapter3
{
    public class PathPicker
    {
        private PointF? _start;
        private PointF? _finish;
        private readonly BoardControl _boardControl;

        public Path Path { get; private set; }

        public event EventHandler PathChanged;

        public PathPicker(BoardControl boardControl)
        {
            if (boardControl == null)
                throw new ArgumentNullException(nameof(boardControl));

            _boardControl = boardControl;
            boardControl.MouseDown += BoardControl_MouseDown;
        }

        private void BuildPath()
        {
            var list = new List<Point>();

            Action<PointF?> tryAdd = (point) =>
            {
                if (point == null) return;

                list.Add(new Point(
                    (int)(point.Value.X / _boardControl.Board.TileSize.Width),
                    (int)(point.Value.Y / _boardControl.Board.TileSize.Height)));
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
                _finish = e.Location;

            BuildPath();
        }

        internal void Reset()
        {
            _start = null;
            _finish = null;

            BuildPath();
        }
    }
}