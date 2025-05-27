using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjQuanLyHocPhi
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
            while (true)
            {
                using (FormLogin login = new FormLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        break;

                    using (Form1 main = new Form1())
                    {
                        Application.Run(main);
                        if (!main.LoggedOut)
                            break;
                    }
                }
            }
        }

    }
}
