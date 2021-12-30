using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarketManagment.Main
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // create database
            DBHelper.CreateDB();

            // create xmls
            SaleForms.ShortcutButtonXmlHelper.CreateXml();
            SaleForms.SaleConfirmXmlHelper.CreateXml();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
