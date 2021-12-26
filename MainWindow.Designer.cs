
using System.Drawing;

namespace autoserviceAppication
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowDetailsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addCardToolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cardsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ShowEmployeesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolMenu,
            this.editToolMenu});
            resources.ApplyResources(this.menuBar, "menuBar");
            this.menuBar.Name = "menuBar";
            // 
            // fileToolMenu
            // 
            this.fileToolMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDetailsMenuItem,
            this.ShowEmployeesMenuItem});
            this.fileToolMenu.Name = "fileToolMenu";
            resources.ApplyResources(this.fileToolMenu, "fileToolMenu");
            // 
            // ShowDetailsMenuItem
            // 
            this.ShowDetailsMenuItem.Name = "ShowDetailsMenuItem";
            resources.ApplyResources(this.ShowDetailsMenuItem, "ShowDetailsMenuItem");
            this.ShowDetailsMenuItem.Click += new System.EventHandler(this.ShowDetailsMenuItem_Click);
            // 
            // editToolMenu
            // 
            this.editToolMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCardToolMenu});
            this.editToolMenu.Name = "editToolMenu";
            resources.ApplyResources(this.editToolMenu, "editToolMenu");
            // 
            // addCardToolMenu
            // 
            this.addCardToolMenu.Name = "addCardToolMenu";
            resources.ApplyResources(this.addCardToolMenu, "addCardToolMenu");
            this.addCardToolMenu.Click += new System.EventHandler(this.addCardToolMenu_Click);
            // 
            // cardsPanel
            // 
            resources.ApplyResources(this.cardsPanel, "cardsPanel");
            this.cardsPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cardsPanel.Name = "cardsPanel";
            // 
            // ShowEmployeesMenuItem
            // 
            this.ShowEmployeesMenuItem.Name = "ShowEmployeesMenuItem";
            resources.ApplyResources(this.ShowEmployeesMenuItem, "ShowEmployeesMenuItem");
            this.ShowEmployeesMenuItem.Click += new System.EventHandler(this.ShowEmployeesMenuItem_Click);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.cardsPanel);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileToolMenu;
        private System.Windows.Forms.ToolStripMenuItem editToolMenu;
        private System.Windows.Forms.ToolStripMenuItem addCardToolMenu;
        private System.Windows.Forms.FlowLayoutPanel cardsPanel;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem ShowDetailsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowEmployeesMenuItem;
    }
}

