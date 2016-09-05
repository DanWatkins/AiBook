using DanWatkins.AiSystem.Views;
using Eto.Forms;

namespace DanWatkins.AiSystem
{
    public partial class MainForm
    {
        private BoardDrawable MainBoardDrawable { get; set; }

        private ButtonToolItem PickPathRadioToolItem { get; set; }

        private CheckToolItem PaintTilesRadioToolItem { get; set; }
    }
}