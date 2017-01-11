using System;
using Eto;
using Eto.Forms;

namespace DanWatkins.AiSystem
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Platform.Detect).Run(new Views.MainView());
        }
    }
}