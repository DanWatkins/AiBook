using DanWatkins.AiSystem.Views;
using DanWatkins.AiSystem.Model;
using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DanWatkins.AiSystem.ViewModels
{
    public class MainViewModel
    {
        private bool _isPicking = false;
        private PointF? _start;
        private PointF? _finish;

        public Board Board { get; }

        public bool EnablePainting { get; set; }

        public Path CurrentPath { get; private set; }

        public event EventHandler PathChanged;

        public event EventHandler BoardChanged;

        public MouseCommand MouseDown { get; } = new MouseCommand();

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
            }
        }

        public MainViewModel(Board board)
        {
            if (board == null)
                throw new ArgumentNullException(nameof(board));

            Board = board;
            MouseDown.Executed += MouseDown_Executed;
        }

        public void PaintTile(float x, float y)
        {
            if (!EnablePainting)
                return;

            var point = new Point(
                (int)(x / Board.TileSize.Width),
                (int)(y / Board.TileSize.Height));

            Board.Tiles[point.X + point.Y * Board.Size.Width] = Tile.Block;
            BoardChanged?.Invoke(this, EventArgs.Empty);
        }

        private void BuildPath()
        {
            var list = new List<Point>();

            Action<PointF?> tryAdd = (point) =>
            {
                if (point == null) return;

                list.Add(new Point(
                    (int)(point.Value.X / Board.TileSize.Width),
                    (int)(point.Value.Y / Board.TileSize.Height)));
            };

            tryAdd(_start);
            tryAdd(_finish);

            CurrentPath = new Path(list);
            Board.Path = CurrentPath;
            PathChanged?.Invoke(this, EventArgs.Empty);
        }

        private void MouseDown_Executed(object sender, MouseEventArgs e)
        {
            PaintTile(e.Location.X, e.Location.Y);

            if (_start == null)
                _start = e.Location;
            else if (_finish == null)
            {
                _finish = e.Location;
            }

            BuildPath();
        }
    }
}