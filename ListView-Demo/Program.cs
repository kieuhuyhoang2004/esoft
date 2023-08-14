using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListView_Demo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           /* Type settingsType = typeof(Control);
            var defaultFontField = settingsType.GetField("defaultFont", BindingFlags.Static | BindingFlags.NonPublic);
            defaultFontField.SetValue(null, new Font("Segoe UI", 8.25F));*/
            Application.Run(new Form1());
        }
    }
}
