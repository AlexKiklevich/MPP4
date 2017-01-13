using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Mpp.RssReader
{
    public partial class FiltresSettigForm : Form
    {
        public FiltresSettigForm()
        {
            InitializeComponent();
            addInListForm.Height = 130;
            addEXListForm.Height = 130;
        }
        private UserConfRead setting;
        Form addInListForm = new Form();
        Form addEXListForm = new Form();
        TextBox textBox = new TextBox();
        ListView currentListView = new ListView();

        private void saveInXMLFile(UserConfRead set)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("root");
            XElement user = new XElement("user");
            XAttribute userName = new XAttribute("name", set.UserName);
            user.Add(userName);
            XElement thread = new XElement("thread");
            XAttribute threadCount = new XAttribute("count", set.ThreadCount);
            thread.Add(threadCount);
            user.Add(thread);
            XElement channels = new XElement("channels");
            foreach (Channel channel in set.channelslist)
            {
                XElement chl = new XElement("channel");
                XAttribute url = new XAttribute("url", channel.Url);
                chl.Add(url);
                channels.Add(chl);
            }
            user.Add(channels);
            XElement filters = new XElement("filters");
            XElement include = new XElement("include");
            XAttribute method = new XAttribute("method", set.includeMethod);
            include.Add(method);
            foreach (string inFilter in set.includeFilters)
            {
                XElement item = new XElement("item");
                item.Add(inFilter);
                include.Add(item);
            }
            if (set.includeFilters.Count != 0)
                filters.Add(include);
            include = new XElement("exclude");
            method = new XAttribute("method", set.excludeMethod);
            include.Add(method);
            foreach (string exFilter in set.excludeFilters)
            {
                XElement item = new XElement("item");
                item.Add(exFilter);
                include.Add(item);
            }
            if (set.excludeFilters.Count != 0)
                filters.Add(include);
            if (set.includeFilters.Count != 0 || set.excludeFilters.Count != 0)
                user.Add(filters);
            root.Add(user);
            doc.Add(root);
            doc.Save(set.fileName);
        }

        public void SetValueInForm(UserConfRead current)
        {
            setting = current;
            tbUserName.Text = current.UserName;
            tbThreadCount.Text = current.ThreadCount.ToString();
            excludeFiltersBox.Text = current.excludeMethod;
            includeFiltersBox.Text = current.includeMethod;
            /*tbExMethod.Text = current.excludeMethod;
            tbInMethod.Text = current.includeMethod;*/
            foreach (Channel channel in current.channelslist)
            {
                listChannels.Items.Add(channel.Url);
            }
            foreach (string inFilters in current.includeFilters)
            {
                listInFilters.Items.Add(inFilters);
            }
            foreach (string exFilters in current.excludeFilters)
            {
                listExFilters.Items.Add(exFilters);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox.Top = 20;
            textBox.Left = 40;
            textBox.Width = 200;
            textBox.Parent = addInListForm;
            Button btnOk = new Button();
            btnOk.Text = "Add";
            btnOk.Parent = addInListForm;
            Button btnCancel = new Button();
            btnOk.Top = 50;
            btnOk.Left = 40;
            btnOk.Click += btnOkClick;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancelClick;
            btnCancel.Top = 50;
            btnCancel.Left = 165;
            btnCancel.Parent = addInListForm;
            addInListForm.ShowDialog();
            currentListView = listChannels;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox.Top = 20;
            textBox.Left = 40;
            textBox.Width = 200;
            textBox.Parent = addInListForm;
            Button btnOk = new Button();
            btnOk.Text = "Add";
            btnOk.Click += InbtnOkClick;
            btnOk.Parent = addInListForm;
            Button btnCancel = new Button();
            btnOk.Top = 50;
            btnOk.Left = 40;
            btnCancel.Text = "Cancel";
            btnCancel.Click += InbtnCancelClick;
            btnCancel.Top = 50;
            btnCancel.Left = 165;
            btnCancel.Parent = addInListForm;
            addInListForm.ShowDialog();
            currentListView = listInFilters;
        }

        private void InbtnOkClick(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                foreach (ListViewItem item in listInFilters.Items)
                {
                    if (item.Text == textBox.Text)
                    {
                        MessageBox.Show("Existing value");
                        textBox.Clear();
                        addInListForm.Close();
                        return;
                    }
                }
                listInFilters.Items.Add(textBox.Text);
                addInListForm.Close();
                textBox.Clear();
            }
            else
                MessageBox.Show("You have not entered a value!");
        }

        private void InbtnCancelClick(object sender, EventArgs e)
        {
            textBox.Clear();
            addInListForm.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox.Top = 20;
            textBox.Left = 40;
            textBox.Width = 200;
            textBox.Parent = addEXListForm;
            Button btnOk = new Button();
            btnOk.Click += ExbtnOkClick;
            btnOk.Text = "Add";
            btnOk.Parent = addEXListForm;
            Button btnCancel = new Button();
            btnOk.Top = 50;
            btnOk.Left = 40;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnEXCancelClick;
            btnCancel.Top = 50;
            btnCancel.Left = 165;
            btnCancel.Parent = addEXListForm;
            addEXListForm.ShowDialog();
            currentListView = listExFilters;
        }

        private void btnEXCancelClick(object sender, EventArgs e)
        {
            textBox.Clear();
            addEXListForm.Close();
        }

        private void ExbtnOkClick(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                foreach( ListViewItem item in listExFilters.Items)
                {
                    if (item.Text == textBox.Text)
                    {
                        MessageBox.Show("Existing value");
                        textBox.Clear();
                        addInListForm.Close();
                        return;
                    }
                }
                listExFilters.Items.Add(textBox.Text);
                addEXListForm.Close();
                textBox.Clear();
            }
            else
                MessageBox.Show("You have not entered a value!");
        }

        private void saveSettingBtn_Click(object sender, EventArgs e)
        {
            try
            {
                setting.UserName = tbUserName.Text;
                setting.ThreadCount = Int32.Parse(tbThreadCount.Text);
                if (excludeFiltersBox.SelectedItem != null)
                    setting.excludeMethod = excludeFiltersBox.SelectedItem.ToString();
                if (includeFiltersBox.SelectedItem != null)
                    setting.includeMethod = includeFiltersBox.SelectedItem.ToString();
                setting.channelslist.Clear();
                setting.includeFilters.Clear();
                setting.excludeFilters.Clear();
                foreach (ListViewItem channel in listChannels.Items)
                {
                    setting.channelslist.Add(new Channel(channel.Text));
                }
                foreach (ListViewItem inFilter in listInFilters.Items)
                {
                    setting.includeFilters.Add(inFilter.Text);
                }
                foreach (ListViewItem exFilter in listExFilters.Items)
                {
                    setting.excludeFilters.Add(exFilter.Text);
                }
                Program.readerform.currentSetting = setting;
                SaveInXMLFile(setting);
                this.Close();
                Program.readerform.updateUserData();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                tbThreadCount.Text = setting.ThreadCount.ToString();
            }
        }
        private void SaveInXMLFile(UserConfRead set)
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("root");
            XElement user = new XElement("user");
            XAttribute userName = new XAttribute("name", set.UserName);
            user.Add(userName);
            XElement thread = new XElement("thread");
            XAttribute threadCount = new XAttribute("count", set.ThreadCount);
            thread.Add(threadCount);
            user.Add(thread);
            XElement channels = new XElement("channels");
            foreach (Channel channel in set.channelslist)
            {
                XElement chl = new XElement("channel");
                XAttribute url = new XAttribute("url", channel.Url);
                chl.Add(url);
                channels.Add(chl);
            }
            user.Add(channels);
            XElement filters = new XElement("filters");
            XElement include = new XElement("include");
            XAttribute method = new XAttribute("method", set.includeMethod);
            include.Add(method);
            foreach (string inFilter in set.includeFilters)
            {
                XElement item = new XElement("item");
                item.Add(inFilter);
                include.Add(item);
            }
            if (set.includeFilters.Count != 0)
                filters.Add(include);
            include = new XElement("exclude");
            method = new XAttribute("method", set.excludeMethod);
            include.Add(method);
            foreach (string exFilter in set.excludeFilters)
            {
                XElement item = new XElement("item");
                item.Add(exFilter);
                include.Add(item);
            }
            if (set.excludeFilters.Count != 0)
                filters.Add(include);
            if (set.includeFilters.Count != 0 || set.excludeFilters.Count != 0)
                user.Add(filters);
            root.Add(user);
            doc.Add(root);
            doc.Save(set.fileName);
        }
        private bool CheckURL(String url)
        {
            if (String.IsNullOrEmpty(url))
                return false;

            try
            {
                WebRequest request = WebRequest.Create(url);

                HttpWebResponse res = request.GetResponse() as HttpWebResponse;

                if (res.StatusDescription == "OK")
                    return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }

        private void listChannels_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentListView = (ListView)sender;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Top = 20;
            textBox.Left = 40;
            textBox.Width = 200;
            textBox.Parent = addInListForm;
            Button btnOk = new Button();
            btnOk.Text = "Add";
            btnOk.Parent = addInListForm;
            Button btnCancel = new Button();
            btnOk.Top = 50;
            btnOk.Left = 40;
            btnOk.Click += btnOkClick;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancelClick;
            btnCancel.Top = 50;
            btnCancel.Left = 165;
            btnCancel.Parent = addInListForm;
            addInListForm.ShowDialog();
        }

        private void btnCancelClick(object sender, EventArgs e)
        {
            textBox.Clear();
            addInListForm.Close();
        }

        private void btnOkClick(object sender, EventArgs e)
        {
            if (textBox.Text != "")
            {
                if (!currentListView.Equals(listChannels) || CheckURL(textBox.Text))
                {
                    currentListView.Items.Add(textBox.Text);
                    textBox.Clear();
                    addInListForm.Close();
                }
            }
            else
                MessageBox.Show("You have not entered a value!");
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            currentListView.Items.Remove(currentListView.SelectedItems[0]);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (currentListView.SelectedItems.Count == 0 || currentListView.SelectedItems.Count > 1)
                deleteToolStripMenuItem.Enabled = false;
            else
                deleteToolStripMenuItem.Enabled = true;
        }

        private void tbThreadCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Close();
            }
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void excludeFiltersBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void includeFiltersBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void listInFilters_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                currentListView = (ListView)sender;
                contextMenuStrip1.Show(e.X + 350,e.Y + 200);
            }
        }
    }
}
