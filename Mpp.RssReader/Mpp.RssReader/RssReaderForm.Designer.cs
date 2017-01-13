namespace Mpp.RssReader
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChanelsItemsdataGridView = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PubDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChanelslistView = new System.Windows.Forms.ListView();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChanelsItemsdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectToolStripMenuItem,
            this.changeUserToolStripMenuItem,
            this.filtresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1146, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ConnectToolStripMenuItem
            // 
            this.ConnectToolStripMenuItem.Name = "ConnectToolStripMenuItem";
            this.ConnectToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.ConnectToolStripMenuItem.Text = "New Connect";
            this.ConnectToolStripMenuItem.Click += new System.EventHandler(this.ConnectToolStripMenuItem_Click);
            // 
            // changeUserToolStripMenuItem
            // 
            this.changeUserToolStripMenuItem.Name = "changeUserToolStripMenuItem";
            this.changeUserToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.changeUserToolStripMenuItem.Text = "Change User";
            // 
            // filtresToolStripMenuItem
            // 
            this.filtresToolStripMenuItem.Name = "filtresToolStripMenuItem";
            this.filtresToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtresToolStripMenuItem.Text = "Filtres";
            this.filtresToolStripMenuItem.Click += new System.EventHandler(this.filtresToolStripMenuItem_Click);
            // 
            // ChanelsItemsdataGridView
            // 
            this.ChanelsItemsdataGridView.AllowUserToAddRows = false;
            this.ChanelsItemsdataGridView.AllowUserToDeleteRows = false;
            this.ChanelsItemsdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ChanelsItemsdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Link,
            this.Description,
            this.PubDate,
            this.Category,
            this.ID});
            this.ChanelsItemsdataGridView.Location = new System.Drawing.Point(12, 51);
            this.ChanelsItemsdataGridView.Name = "ChanelsItemsdataGridView";
            this.ChanelsItemsdataGridView.Size = new System.Drawing.Size(923, 341);
            this.ChanelsItemsdataGridView.TabIndex = 3;
            this.ChanelsItemsdataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ChanelsItemsdataGridView_CellMouseDoubleClick);
            // 
            // Title
            // 
            this.Title.Frozen = true;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 380;
            // 
            // Link
            // 
            this.Link.Frozen = true;
            this.Link.HeaderText = "Link";
            this.Link.Name = "Link";
            this.Link.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.Frozen = true;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // PubDate
            // 
            this.PubDate.Frozen = true;
            this.PubDate.HeaderText = "PubDate";
            this.PubDate.Name = "PubDate";
            this.PubDate.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.Frozen = true;
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // ChanelslistView
            // 
            this.ChanelslistView.CheckBoxes = true;
            this.ChanelslistView.Location = new System.Drawing.Point(941, 51);
            this.ChanelslistView.Name = "ChanelslistView";
            this.ChanelslistView.Size = new System.Drawing.Size(182, 341);
            this.ChanelslistView.TabIndex = 2;
            this.ChanelslistView.UseCompatibleStateImageBehavior = false;
            this.ChanelslistView.View = System.Windows.Forms.View.List;
            // 
            // ReloadButton
            // 
            this.ReloadButton.Location = new System.Drawing.Point(860, 408);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(75, 23);
            this.ReloadButton.TabIndex = 3;
            this.ReloadButton.Text = "Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current user:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 509);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.ChanelslistView);
            this.Controls.Add(this.ChanelsItemsdataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1162, 548);
            this.MinimumSize = new System.Drawing.Size(1162, 548);
            this.Name = "MainForm";
            this.Text = "RssReader";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChanelsItemsdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtresToolStripMenuItem;
        private System.Windows.Forms.DataGridView ChanelsItemsdataGridView;
        private System.Windows.Forms.ListView ChanelslistView;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn PubDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}

