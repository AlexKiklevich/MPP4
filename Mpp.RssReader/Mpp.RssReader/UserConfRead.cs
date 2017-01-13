using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mpp.RssReader
{
    public class UserConfRead
    {
        private string username;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        private int threadcount;
        public int ThreadCount
        {
            get { return threadcount; }
            set { threadcount = value; }
        }
        public List<Channel> channelslist = new List<Channel> { };
        public List<string> includeFilters = new List<string>();
        public List<string> excludeFilters = new List<string>();

        public string includeMethod = "";
        public string excludeMethod = "";
        public string fileName = "";

        public UserConfRead()
        {
            XmlDocument doc = new XmlDocument();
            OpenFileDialog filedialog = new OpenFileDialog();
            Stream Mystream = null;

            filedialog.InitialDirectory = @"C:\Users\Sasha\Documents\Visual Studio 2015\Projects\Mpp.RssReader\Mpp.RssReader\bin\Debug";
            filedialog.Filter = "XML files (*.xml)|*.xml";
            filedialog.RestoreDirectory = true;
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if((Mystream = filedialog.OpenFile()) != null)
                    {
                        using (Mystream)
                        {
                            doc.Load(filedialog.FileName);
                            fileName = filedialog.FileName;
                            XmlNode root = doc.SelectNodes("root")[0];
                            XmlNode user = root.FirstChild;
                            foreach (XmlAttribute name in user.Attributes)
                            {
                                username = name.Value;
                            }
                            foreach (XmlNode node in user.ChildNodes)
                            {
                                switch(node.Name)
                                {
                                    case "thread":
                                    {
                                         threadcount = Int32.Parse(node.Attributes[0].Value);
                                         break;
                                    }
                                    case "channels":
                                    {
                                        foreach (XmlNode channel in node.ChildNodes)
                                        {
                                             channelslist.Add(new Channel(channel.Attributes[0].Value));
                                        }
                                        break;
                                    }
                                    case "filters":
                                    {
                                            foreach (XmlNode temp in node.SelectNodes("include"))
                                            {
                                                includeMethod = temp.Attributes[temp.Attributes.Count - 1].Value;
                                                foreach (XmlNode item in temp.ChildNodes)
                                                {
                                                    includeFilters.Add(item.InnerText);
                                                }
                                            }
                                            foreach (XmlNode temp in node.SelectNodes("exclude"))
                                            {
                                                excludeMethod = temp.Attributes[temp.Attributes.Count - 1].Value;
                                                foreach (XmlNode item in temp.ChildNodes)
                                                {
                                                    excludeFilters.Add(item.InnerText);
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
