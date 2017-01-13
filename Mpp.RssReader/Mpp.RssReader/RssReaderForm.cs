using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Mpp.RssReader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Thread thr;
        UserConfRead setting;
        ThreadPool tp;
        public List<UserConfRead> listSetting = new List<UserConfRead>();
        public UserConfRead currentSetting;
        private static string pattern = "\\<.*?\\>";
        private Regex regex = new Regex(pattern);
        Thread checkThread;

        private void checkButton()
        {
            while (true)
            {
                if (tp != null)
                {
                    if (tp.isEmpty())
                        ReloadButton.Invoke(new Action(() => ReloadButton.Enabled = true));
                    else
                        ReloadButton.Invoke(new Action(() => ReloadButton.Enabled = false));
                }
            }
        }
        private void initialTP(object param)
        {
            ChanelsItemsdataGridView.Invoke(new Action(() =>
            {
                ChanelsItemsdataGridView.Rows.Clear();
            }));
            UserConfRead setting = (UserConfRead)param;
            foreach (Channel channel in setting.channelslist)
            {
                if (channel.IsSelected)
                    tp.Execute(new Task(parce, channel.Url));
            }
        }

        private List<RssItem> parce(string channelUrl)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(channelUrl);
                XmlNode channel = doc.ChildNodes[1].FirstChild;
                List<RssItem> rssItems = new List<RssItem>();
                RssItem rssItem;
                foreach (XmlNode item in channel.SelectNodes("item"))
                {
                    if (checkItemOfFilters(item))
                    {
                        rssItem = new RssItem(
                            item.SelectSingleNode("title").InnerText,
                            item.SelectSingleNode("link").InnerText,
                            regex.Replace(item.SelectSingleNode("description").InnerText, ""),
                            item.SelectSingleNode("category") != null ? item.SelectSingleNode("category").InnerText : "",
                            item.SelectSingleNode("pubDate").InnerText
                        );

                        lock (this)
                        {
                            ChanelsItemsdataGridView.Invoke(new Action(() =>
                            {
                                if (checkInDataGridView(rssItem))
                                {
                                    int rowNumber = ChanelsItemsdataGridView.Rows.Add();
                                    ChanelsItemsdataGridView.Rows[rowNumber].Cells["Title"].Value = rssItem.Title;
                                    ChanelsItemsdataGridView.Rows[rowNumber].Cells["Category"].Value = rssItem.Category;
                                    ChanelsItemsdataGridView.Rows[rowNumber].Cells["Description"].Value = rssItem.Description;
                                    ChanelsItemsdataGridView.Rows[rowNumber].Cells["PubDate"].Value = rssItem.PubDate;
                                    ChanelsItemsdataGridView.Rows[rowNumber].Cells["Link"].Value = rssItem.Link;
                                    ChanelsItemsdataGridView.Rows[rowNumber].Cells["ID"].Value = ChanelsItemsdataGridView.Rows.Count;
                                }
                            }));
                        }
                        rssItems.Add(rssItem);
                    }
                }
                return rssItems;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return null;
            }
        }

        private bool checkInDataGridView(RssItem rssItem)
        {
            foreach (DataGridViewRow row in ChanelsItemsdataGridView.Rows)
            {
                if (((string)row.Cells["Title"].Value == rssItem.Title) && ((string)row.Cells["Link"].Value == rssItem.Link))
                    return false;
            }
            return true;
        }

        private bool checkIncludeFilters(string str)
        {
            if (currentSetting.includeMethod == "or")
            {
                foreach (string inFilter in currentSetting.includeFilters)
                {
                    if (str.Contains(inFilter.ToUpper()))
                        return true;
                }
            }
            else if (currentSetting.includeMethod == "and")
            {
                int count = 0;
                foreach (string inFilter in currentSetting.includeFilters)
                {
                    if (str.Contains(inFilter.ToUpper()))
                        count++;
                }
                if (count == currentSetting.includeFilters.Count)
                    return true;
                else
                    return false;
            }
            return false;
        }

        private bool checkExcludeFilters(string str)
        {
            if (currentSetting.excludeMethod == "or")
            {
                foreach (string exFilter in currentSetting.excludeFilters)
                {
                    if (str.Contains(exFilter.ToUpper()))
                        return true;
                }
            }
            else if (currentSetting.excludeMethod == "and")
            {
                int count = 0;
                foreach (string exFilter in currentSetting.excludeFilters)
                {
                    if (str.Contains(exFilter.ToUpper()))
                        count++;
                }
                if (count == currentSetting.excludeFilters.Count)
                    return true; 
                else
                    return false;
            }
            return false;
        }

        private bool checkString(string str)
        {
            if ((currentSetting.includeFilters.Count == 0 || checkIncludeFilters(str)) &&
                (currentSetting.excludeFilters.Count == 0 || checkExcludeFilters(str)))
                return true;
            else
                return false;
        }
        private bool checkItemOfFilters(XmlNode item)
        {
            if (currentSetting.excludeFilters.Count == 0 && currentSetting.includeFilters.Count == 0)
                return true;

            string title = item.SelectSingleNode("title") != null ? item.SelectSingleNode("title").InnerText.ToUpper() : "";
            string description = item.SelectSingleNode("description") != null ? item.SelectSingleNode("description").InnerText.ToUpper() : "";
            string category = item.SelectSingleNode("category") != null ? item.SelectSingleNode("category").InnerText.ToUpper() : "";

            if ((currentSetting.includeFilters.Count == 0 || checkIncludeFilters(title) || checkIncludeFilters(description) || checkIncludeFilters(category)) &&
                (currentSetting.excludeFilters.Count == 0 || (!checkExcludeFilters(title) && !checkExcludeFilters(description) && !checkExcludeFilters(category))))
                return true;
            else
                return false;
        }

        private void ConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                setting = new UserConfRead();
                if (setting.UserName != null)
                {
                    if (!changeUserToolStripMenuItem.DropDownItems.ContainsKey(setting.UserName))
                    {
                        ReloadButton.Enabled = true;
                        listSetting.Add(setting);
                        currentSetting = setting;
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Text = setting.UserName;
                        item.Name = setting.UserName;
                        changeUserToolStripMenuItem.DropDownItems.Add(item);
                        changeUserToolStripMenuItem.DropDownItems.Find(setting.UserName, false).First().Click += menuItemClick;
                        label1.Text = "Current User: " + setting.UserName;
                        ChanelslistView.Items.Clear();
                        ListViewItem lvi;
                        foreach (Channel channel in setting.channelslist)
                        {
                            lvi = new ListViewItem();
                            lvi.Text = channel.Url;
                            lvi.Checked = true;
                            ChanelslistView.Items.Add(lvi);
                        }
                        if (tp == null)
                        {
                            checkThread = new Thread(checkButton) { IsBackground = true };
                            checkThread.Start();
                        }
                        tp = new ThreadPool(setting.ThreadCount);
                        thr = new Thread(new ParameterizedThreadStart(initialTP)) { IsBackground = true };
                        thr.Start(setting);
                    }
                    else
                    {
                        MessageBox.Show("This file is already open!");
                    }
                }
                else
                {
                    MessageBox.Show("You choose the configuration file!");
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void menuItemClick(object sender, EventArgs e)
        {
            setting = listSetting.Find(x => x.UserName == sender.ToString());
            currentSetting = setting;
            try
            {
                label1.Text = "Current User: " + setting.UserName;
                int i = 0;
                ChanelslistView.Items.Clear();
                foreach (Channel channel in setting.channelslist)
                {
                    ChanelslistView.Items.Add(channel.Url);
                    ChanelslistView.Items[i].Checked = true;
                    i++;
                }
                thr = new Thread(new ParameterizedThreadStart(initialTP)) { IsBackground = true };
                thr.Start(setting);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        public void updateUserData()
        {
            listSetting.Remove(listSetting.Find(x => x.UserName == currentSetting.UserName));
            listSetting.Add(currentSetting);
            menuItemClick(currentSetting.UserName, new EventArgs());
        }

        private void filtresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSetting != null)
            {
                FiltresSettigForm form = new FiltresSettigForm();
                form.SetValueInForm(currentSetting);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("User was not selected!");
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            ChanelsItemsdataGridView.Rows.Clear();
            int i = 0;
            foreach (ListViewItem item in ChanelslistView.Items)
            {
                if (item.Checked != true)
                {
                    setting.channelslist[i].IsSelected = false;
                }
                else
                    setting.channelslist[i].IsSelected = true;
                i++;
            }
            thr = new Thread(new ParameterizedThreadStart(initialTP)) { IsBackground = true };
            thr.Start(setting);
        }

        private void ChanelsItemsdataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Process.Start((string)ChanelsItemsdataGridView.Rows[e.RowIndex].Cells["Link"].Value);
        }
    }
}
