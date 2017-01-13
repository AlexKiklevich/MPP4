namespace Mpp.RssReader
{
    partial class FiltresSettigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.excludeFiltersBox = new System.Windows.Forms.ComboBox();
            this.includeFiltersBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbThreadCount = new System.Windows.Forms.TextBox();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listExFilters = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listInFilters = new System.Windows.Forms.ListView();
            this.listChannels = new System.Windows.Forms.ListView();
            this.saveSettingBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // excludeFiltersBox
            // 
            this.excludeFiltersBox.FormattingEnabled = true;
            this.excludeFiltersBox.Items.AddRange(new object[] {
            "and",
            "or"});
            this.excludeFiltersBox.Location = new System.Drawing.Point(395, 56);
            this.excludeFiltersBox.Name = "excludeFiltersBox";
            this.excludeFiltersBox.Size = new System.Drawing.Size(121, 21);
            this.excludeFiltersBox.TabIndex = 24;
            this.excludeFiltersBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.excludeFiltersBox_KeyPress);
            // 
            // includeFiltersBox
            // 
            this.includeFiltersBox.FormattingEnabled = true;
            this.includeFiltersBox.Items.AddRange(new object[] {
            "and",
            "or"});
            this.includeFiltersBox.Location = new System.Drawing.Point(395, 21);
            this.includeFiltersBox.Name = "includeFiltersBox";
            this.includeFiltersBox.Size = new System.Drawing.Size(121, 21);
            this.includeFiltersBox.TabIndex = 23;
            this.includeFiltersBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.includeFiltersBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Method exclude filters:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Method include filters:";
            // 
            // tbThreadCount
            // 
            this.tbThreadCount.Location = new System.Drawing.Point(107, 56);
            this.tbThreadCount.Name = "tbThreadCount";
            this.tbThreadCount.Size = new System.Drawing.Size(100, 20);
            this.tbThreadCount.TabIndex = 20;
            this.tbThreadCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbThreadCount_KeyPress);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(107, 21);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 20);
            this.tbUserName.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Thread count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "User name:";
            // 
            // listExFilters
            // 
            this.listExFilters.ContextMenuStrip = this.contextMenuStrip1;
            this.listExFilters.Location = new System.Drawing.Point(590, 90);
            this.listExFilters.Name = "listExFilters";
            this.listExFilters.Size = new System.Drawing.Size(225, 389);
            this.listExFilters.TabIndex = 27;
            this.listExFilters.UseCompatibleStateImageBehavior = false;
            this.listExFilters.View = System.Windows.Forms.View.List;
            this.listExFilters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listChannels_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // listInFilters
            // 
            this.listInFilters.Location = new System.Drawing.Point(337, 90);
            this.listInFilters.Name = "listInFilters";
            this.listInFilters.Size = new System.Drawing.Size(225, 389);
            this.listInFilters.TabIndex = 26;
            this.listInFilters.UseCompatibleStateImageBehavior = false;
            this.listInFilters.View = System.Windows.Forms.View.List;
            this.listInFilters.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listInFilters_MouseDown);
            // 
            // listChannels
            // 
            this.listChannels.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listChannels.ContextMenuStrip = this.contextMenuStrip1;
            this.listChannels.HoverSelection = true;
            this.listChannels.Location = new System.Drawing.Point(85, 90);
            this.listChannels.Name = "listChannels";
            this.listChannels.Size = new System.Drawing.Size(220, 389);
            this.listChannels.TabIndex = 25;
            this.listChannels.UseCompatibleStateImageBehavior = false;
            this.listChannels.View = System.Windows.Forms.View.List;
            this.listChannels.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listChannels_MouseDown);
            // 
            // saveSettingBtn
            // 
            this.saveSettingBtn.Location = new System.Drawing.Point(800, 541);
            this.saveSettingBtn.Name = "saveSettingBtn";
            this.saveSettingBtn.Size = new System.Drawing.Size(75, 23);
            this.saveSettingBtn.TabIndex = 31;
            this.saveSettingBtn.Text = "Save";
            this.saveSettingBtn.UseVisualStyleBackColor = true;
            this.saveSettingBtn.Click += new System.EventHandler(this.saveSettingBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(643, 485);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 23);
            this.button3.TabIndex = 30;
            this.button3.Text = "Add exclude filter";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(394, 485);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 29;
            this.button2.Text = "Add include filter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(144, 485);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "Add channel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FiltresSettigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 598);
            this.Controls.Add(this.saveSettingBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listExFilters);
            this.Controls.Add(this.listInFilters);
            this.Controls.Add(this.listChannels);
            this.Controls.Add(this.excludeFiltersBox);
            this.Controls.Add(this.includeFiltersBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbThreadCount);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(917, 637);
            this.MinimumSize = new System.Drawing.Size(917, 637);
            this.Name = "FiltresSettigForm";
            this.Text = "FiltresSettigForm";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox excludeFiltersBox;
        private System.Windows.Forms.ComboBox includeFiltersBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbThreadCount;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listExFilters;
        private System.Windows.Forms.ListView listInFilters;
        private System.Windows.Forms.ListView listChannels;
        private System.Windows.Forms.Button saveSettingBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}