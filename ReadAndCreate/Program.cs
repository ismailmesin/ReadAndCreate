using System.Xml;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;


namespace ReadAndCreate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new();

            doc.Load(@"C:\Users\ismail\Desktop\ReadAndCreate\ReadAndCreate\Data.xml");


            XmlNodeList nodeList = doc.SelectNodes("//body/trans-unit");


            foreach (XmlNode node in nodeList)
            {
                string id = node.Attributes["id"].Value;
                XmlNode unit = node.SelectSingleNode("target");
                if (id == "42007")
                {
                    Console.WriteLine(unit.InnerText);

                    string data = unit.InnerText;

                    XmlDocument newDoc = new();
                    newDoc.LoadXml($"<body><trans-unit>{data}</trans-unit></body>");
                    newDoc.Save("info.xml");

                }

            }
        }
    }
}