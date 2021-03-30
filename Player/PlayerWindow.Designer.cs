
using System;

namespace Player
{
    partial class PlayerWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerWindow));
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimalInterfaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showCurrentPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropdownListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideDropDownPlayListTimer = new System.Windows.Forms.Timer(this.components);
            this.playlistPanel1 = new Player.PlaylistPanel();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(0, 24);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(800, 426);
            this.player.TabIndex = 0;
            this.player.CurrentPlaylistChange += new AxWMPLib._WMPOCXEvents_CurrentPlaylistChangeEventHandler(this.Player_CurrentPlaylistChange);
            this.player.CurrentItemChange += new AxWMPLib._WMPOCXEvents_CurrentItemChangeEventHandler(this.Player_CurrentItemChange);
            this.player.KeyUpEvent += new AxWMPLib._WMPOCXEvents_KeyUpEventHandler(this.player_KeyUpEvent);
            this.player.MouseMoveEvent += new AxWMPLib._WMPOCXEvents_MouseMoveEventHandler(this.Player_MouseMoveEvent);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playlistToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.DragEnter += new System.Windows.Forms.DragEventHandler(this.PlayerWindow_DragEnter);
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.openPlaylistToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1});
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.playlistToolStripMenuItem.Text = "&Playlist";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addToolStripMenuItem.Text = "Create Playlist";
            // 
            // openPlaylistToolStripMenuItem
            // 
            this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
            this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openPlaylistToolStripMenuItem.Text = "Open Playlist";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteToolStripMenuItem.Text = "Delete Playlist";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimalInterfaceToolStripMenuItem,
            this.toolStripSeparator2,
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripSeparator3,
            this.showCurrentPlaylistToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // minimalInterfaceToolStripMenuItem
            // 
            this.minimalInterfaceToolStripMenuItem.Name = "minimalInterfaceToolStripMenuItem";
            this.minimalInterfaceToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.minimalInterfaceToolStripMenuItem.Text = "Minimal interface";
            this.minimalInterfaceToolStripMenuItem.CheckedChanged += new System.EventHandler(this.minimalInterfaceToolStripMenuItem_CheckedChanged);
            this.minimalInterfaceToolStripMenuItem.Click += new System.EventHandler(this.minimalInterfaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(190, 6);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Checked = true;
            this.alwaysOnTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.CheckedChanged += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_CheckedChanged);
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(190, 6);
            // 
            // showCurrentPlaylistToolStripMenuItem
            // 
            this.showCurrentPlaylistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dropdownListToolStripMenuItem,
            this.leftPanelToolStripMenuItem});
            this.showCurrentPlaylistToolStripMenuItem.Name = "showCurrentPlaylistToolStripMenuItem";
            this.showCurrentPlaylistToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.showCurrentPlaylistToolStripMenuItem.Text = "Show current playlist...";
            // 
            // dropdownListToolStripMenuItem
            // 
            this.dropdownListToolStripMenuItem.Name = "dropdownListToolStripMenuItem";
            this.dropdownListToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.dropdownListToolStripMenuItem.Text = "Dropdown List";
            this.dropdownListToolStripMenuItem.CheckedChanged += new System.EventHandler(this.dropdownListToolStripMenuItem_CheckedChanged);
            this.dropdownListToolStripMenuItem.Click += new System.EventHandler(this.dropdownListToolStripMenuItem_Click);
            // 
            // leftPanelToolStripMenuItem
            // 
            this.leftPanelToolStripMenuItem.Name = "leftPanelToolStripMenuItem";
            this.leftPanelToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.leftPanelToolStripMenuItem.Text = "Left Panel";
            this.leftPanelToolStripMenuItem.CheckedChanged += new System.EventHandler(this.leftPanelToolStripMenuItem_CheckedChanged);
            this.leftPanelToolStripMenuItem.Click += new System.EventHandler(this.leftPanelToolStripMenuItem_Click);
            // 
            // HideDropDownPlayListTimer
            // 
            this.HideDropDownPlayListTimer.Interval = 5000;
            this.HideDropDownPlayListTimer.Tick += new System.EventHandler(this.HideDropDownPlayListTimer_Tick);
            // 
            // playlistPanel1
            // 
            this.playlistPanel1.AllowDropLV = false;
            this.playlistPanel1.Location = new System.Drawing.Point(440, 27);
            this.playlistPanel1.MaximumSize = new System.Drawing.Size(360, 4096);
            this.playlistPanel1.MinimalInterface = false;
            this.playlistPanel1.Name = "playlistPanel1";
            this.playlistPanel1.PlayIndex = -1;
            this.playlistPanel1.Size = new System.Drawing.Size(360, 21);
            this.playlistPanel1.TabIndex = 2;
            this.playlistPanel1.ViewMode = PlaylistViewMode.DropDownList;
            // 
            // PlayerWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playlistPanel1);
            this.Controls.Add(this.player);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlayerWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerWindow_FormClosing);
            this.Load += new System.EventHandler(this.PlayerWindow_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.PlayerWindow_DragEnter);
            this.Resize += new System.EventHandler(this.PlayerWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer HideDropDownPlayListTimer;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimalInterfaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showCurrentPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropdownListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftPanelToolStripMenuItem;
        private PlaylistPanel playlistPanel1;
    }
}

