using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace MarketManagement.SaleForms
{
    class SaleConfirmXmlHelper
    {
        public static DirectoryInfo dir = Directory.GetParent(Application.UserAppDataPath);
        public static string _filePath = Path.Combine(dir.FullName, "Günlük Satış Özeti\\DailySaleSummary.xml");
        public static string _folder = Path.Combine(dir.FullName, "Günlük Satış Özeti");

        public static void CreateXml()
        {
            if (File.Exists(_filePath)) return;

            // create root
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("DailySaleSummary");
            doc.AppendChild(root);

            XmlElement dailySale = doc.CreateElement("DailySale");
            dailySale.InnerText = "0.00";
            root.AppendChild(dailySale);

            // save the xml
            Directory.CreateDirectory(_folder);
            doc.Save(_filePath);
        }

        // there is only 1 element for daily sale
        public static void UpdateXmlDailySale(double amount)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNode dailySale = doc.SelectSingleNode("DailySaleSummary/DailySale");

            double containingAmount = double.Parse(dailySale.InnerText);
            containingAmount += amount;

            dailySale.InnerText = containingAmount.ToString("#.00");
            doc.Save(_filePath);
        }

        public static void ResetXmlDailySaleContent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNode dailySale = doc.SelectSingleNode("DailySaleSummary/DailySale");

            dailySale.InnerText = "0.00";
            doc.Save(_filePath);
        }
    
        public static string GetDailySale()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNode dailySale = doc.SelectSingleNode("DailySaleSummary/DailySale");

            return dailySale.InnerText;
        }
    }
}
