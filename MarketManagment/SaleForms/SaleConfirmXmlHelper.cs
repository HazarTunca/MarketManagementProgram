using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace MarketManagment.SaleForms
{
    class SaleConfirmXmlHelper
    {
        public static string _filePath = Application.StartupPath + "SaleSummary\\SaleSummary.xml";
        public static string _folder = Application.StartupPath + "SaleSummary";

        public static void CreateXml()
        {
            if (File.Exists(_filePath)) return;

            // create root
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("SaleSummaries");
            doc.AppendChild(root);

            XmlElement dailySale = doc.CreateElement("DailySale");
            dailySale.InnerText = "0";
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
            XmlNode dailySale = doc.SelectSingleNode("SaleSummaries/DailySale");

            double containingAmount = double.Parse(dailySale.InnerText);
            containingAmount += amount;

            dailySale.InnerText = containingAmount.ToString();
            doc.Save(_filePath);
        }

        public static void ResetXmlDailySaleContent()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNode dailySale = doc.SelectSingleNode("SaleSummaries/DailySale");

            dailySale.InnerText = "0";
            doc.Save(_filePath);
        }
    
        public static string GetDailySale()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNode dailySale = doc.SelectSingleNode("SaleSummaries/DailySale");

            return dailySale.InnerText;
        }
    }
}
