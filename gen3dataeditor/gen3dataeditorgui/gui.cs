using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gen3dataeditorgui
{
    static class gui
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow main = new MainWindow();
            
            Application.EnableVisualStyles();
            
            Application.Run(main);
        }
    }
}
