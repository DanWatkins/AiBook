using DanWatkins.AiSystem.Views;
using Eto.Forms;

namespace DanWatkins.AiSystem.Views
{
    public partial class MainView
    {
        private BoardView MainBoardView { get; set; }

        private RadioToolItem PickPathRadioToolItem { get; set; }

        private RadioToolItem PaintTilesRadioToolItem { get; set; }
    }
}