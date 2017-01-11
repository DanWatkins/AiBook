using System;
using Eto.Forms;
using Eto.Drawing;
using Eto.Serialization.Xaml;
using DanWatkins.AiSystem.ViewModels;
using DanWatkins.AiSystem.Model;

namespace DanWatkins.AiSystem.Views
{
    public partial class MainView : Form
    {
        private readonly MainViewModel _viewModel;

        public MainView()
        {
            XamlReader.Load(this);
            _viewModel = new MainViewModel(new Board(new Size(16, 12), new Size(48, 48)));
            DataContext = _viewModel;

            PaintTilesRadioToolItem.BindDataContext(c => c.Checked, (MainViewModel m) => m.EnablePainting);
            PickPathRadioToolItem.BindDataContext(c => c.Checked, (MainViewModel m) => m.IsPicking);

            MainBoardView.Board = _viewModel.Board;
            MainBoardView.MouseDown += (sender, e) => _viewModel.MouseDown.Execute(this, e);
            _viewModel.PathChanged += PathChanged;
            _viewModel.BoardChanged += BoardChanged;
        }

        private void PathChanged(object sender, EventArgs e)
        {
            MainBoardView.Invalidate();
        }

        private void BoardChanged(object sender, EventArgs e)
        {
            MainBoardView.Invalidate();
        }
    }
}