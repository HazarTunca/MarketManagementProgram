using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace MarketManagment.SaleForms
{
    class ShortcutButtonXmlHelper
    {
        private static string _filePath = Application.StartupPath + "ShortcutButtons\\ShortcutButtons.xml";
        private static string _folder = Application.StartupPath + "ShortcutButtons";

        public static void CreateXml()
        {
            if (File.Exists(_filePath)) return;

            // create root
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("ShortcutButtons");
            doc.AppendChild(root);

            // save the xml
            Directory.CreateDirectory(_folder);
            doc.Save(_filePath);
        }

        public static void AddNewButton(int barcode, string buttonName)
        {
            // button is already exists
            if (IsButtonExists(buttonName))
            {

                return;
            }

            // get the root
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNode root = doc.SelectSingleNode("ShortcutButtons");

            // create parent for button and barcode
            XmlElement newShortcutButton = doc.CreateElement("ShortcutButton");
            root.AppendChild(newShortcutButton);

            // create button element and barcode element
            XmlElement barcodeElem = doc.CreateElement("Barcode");
            XmlElement buttonElem = doc.CreateElement("ButtonName");
            XmlElement buttonHeight = doc.CreateElement("ButtonHeight");
            XmlElement buttonWidth = doc.CreateElement("ButtonWidth");
            newShortcutButton.AppendChild(barcodeElem);
            newShortcutButton.AppendChild(buttonElem);
            newShortcutButton.AppendChild(buttonWidth);
            newShortcutButton.AppendChild(buttonHeight);

            // set button and barcode texts
            barcodeElem.InnerText = barcode.ToString();
            buttonElem.InnerText = buttonName.ToString();
            buttonWidth.InnerText = "100";
            buttonHeight.InnerText = "80";

            doc.Save(_filePath);
        }

        public static void RemoveButton(string buttonName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNodeList buttonsList = doc.SelectNodes("ShortcutButtons/ShortcutButton");

            foreach(XmlNode button in buttonsList)
            {
                string xmlButtonName = button.SelectSingleNode("ButtonName").InnerText;

                if(xmlButtonName == buttonName)
                {
                    XmlNode parent = button.ParentNode;
                    parent.RemoveChild(button);
                    break;
                }
            }
            doc.Save(_filePath);
        }

        public static int GetBarcode(string buttonName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);

            XmlNodeList buttonsList = doc.SelectNodes("ShortcutButtons/ShortcutButton");

            int barcode = -1;

            foreach(XmlNode buttonParent in buttonsList)
            {
                string xmlButtonName = buttonParent.SelectSingleNode("ButtonName").InnerText;

                if (xmlButtonName == buttonName)
                {
                    // get the barcode
                    barcode = int.Parse(buttonParent.SelectSingleNode("Barcode").InnerText);
                    break;
                }
            }

            return barcode;
        }
    
        public static List<string> GetButtonNames()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNodeList buttonsList = doc.SelectNodes("ShortcutButtons/ShortcutButton");

            List<string> buttonNames = new List<string>();

            foreach(XmlNode button in buttonsList)
            {
                string buttonName = button.SelectSingleNode("ButtonName").InnerText;
                buttonNames.Add(buttonName);
            }

            return buttonNames;
        }
    
        public static bool IsButtonExists(string buttonName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(_filePath);
            XmlNodeList buttons = doc.SelectNodes("ShortcutButtons/ShortcutButton");

            foreach (XmlNode button in buttons)
            {
                string xmlButtonName = button.SelectSingleNode("ButtonName").InnerText;

                if (xmlButtonName == buttonName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
