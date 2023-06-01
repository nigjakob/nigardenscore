using OfficeOpenXml;

using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NiGardenScore
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            Application.VisualStyleState = VisualStyleState.NoneEnabled;
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainForm());
        }
    }
}
