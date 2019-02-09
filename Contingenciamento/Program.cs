using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Contingenciamento
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Avisa a Aplicação que o separador de decimal (double) é a vírgula (,)
            //CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();

            ////culture.DateTimeFormat.DateSeparator = "/";
            ////culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

            ////dekadikoi arithmoi
            //culture.NumberFormat.NumberDecimalSeparator = ",";
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;

            Application.Run(new MenuPrincipal());
        }

    }
}
