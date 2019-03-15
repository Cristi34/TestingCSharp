using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestingCSharp
{
    public class TestXML
    {
        public static void ConvertObjectToXML()
        {
            ImportDmSessionData testObj = new ImportDmSessionData();
            Console.WriteLine(GetXMLFromObject(testObj));
        }

        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception ex)
            {
                //Handle Exception Code
                var test = ex.ToString();
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }
    }

    public class ImportDmSessionData
    {
        public int DmRecordsCount;
        public int SessionId;
        public string SessionName;
        public DateTime MessageScheduledExecutionTime;
        public string MessageCampaignTypeTemplate;
        public int MessageEntriesCount;
    }
}
