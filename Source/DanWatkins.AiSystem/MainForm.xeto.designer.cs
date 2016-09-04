using DanWatkins.AiSystem.Views;
using Eto.Forms;

namespace DanWatkins.AiSystem
{
    public partial class MainForm
    {
        private BoardDrawable MainBoardDrawable { get; set; }

        private RadioToolItem PickPathRadioToolItem { get; set; }

        private RadioToolItem PaintTilesRadioToolItem { get; set; }
    }
}