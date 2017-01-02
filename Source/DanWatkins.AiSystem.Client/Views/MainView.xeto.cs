using System;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using DanWatkins.AiSystem.Client.ViewModels;

namespace DanWatkins.AiSystem.Client.Views
{
    public partial class MainView : Form
    {
        private readonly MainViewModel _viewModel;

        public MainView()
        {
            XamlReader.Load(this);
            _viewModel = new MainViewModel(new Board(new Size(16, 12), new Size(48, 48)), MainBoardView);
            DataContext = _viewModel;

            PaintTilesRadioToolItem.BindDataContext(c => c.Checked, (MainViewModel m) => m.EnablePainting);
            PickPathRadioToolItem.BindDataContext(c => c.Checked, (MainViewModel m) => m.IsPicking);

            MainBoardView.Board = _viewModel.Board;
            MainBoardView.MouseDown += MainBoardView_MouseDown;
            _viewModel.PathChanged += PathChanged;
        }

        private void MainBoardView_MouseDown(object sender, MouseEventArgs e)
        {
            _viewModel.PaintTile(e.Location.X, e.Location.Y);
            MainBoardView.Invalidate();
        }

        private void PathChanged(object sender, EventArgs e)
        {
            MainBoardView.Invalidate();
        }
    }
}