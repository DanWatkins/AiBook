using System;
using Eto;
using Eto.Forms;

namespace Atgp.Chapter3
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Platform.Detect).Run(new MainForm());
        }
    }
}