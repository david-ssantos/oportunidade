using David.MS.Application.Interface;
using David.MS.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace David.MS.Application.Apps
{
    public class UtilApp: IUtil
    {
        public T GetXml<T> (string uri)
        {
            WebClient client = new WebClient();
            XmlDocument xmlDoc = new XmlDocument();
            var xml = client.DownloadString(new Uri(uri));

            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                var serializer = new XmlSerializer(typeof(T));
                var rss = (T)serializer.Deserialize(reader);
                return rss;
            }
        }
    }
}
