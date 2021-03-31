
namespace Player
{
    public partial class PlaylistPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playListView = new System.Windows.Forms.ListView();
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playListTools = new System.Windows.Forms.ToolStrip();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.removeButton = new System.Windows.Forms.ToolStripButton();
            this.savePlaylistAs = new System.Windows.Forms.ToolStripButton();
            this.playListTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // playListView
            // 
            this.playListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameCol,
            this.Duration});
            this.playListView.FullRowSelect = true;
            this.playListView.GridLines = true;
            this.playListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playListView.HideSelection = false;
            this.playListView.Location = new System.Drawing.Point(0, 28);
            this.playListView.MultiSelect = false;
            this.playListView.Name = "playListView";
            this.playListView.Size = new System.Drawing.Size(360, 298);
            this.playListView.TabIndex = 0;
            this.playListView.UseCompatibleStateImageBehavior = false;
            this.playListView.View = System.Windows.Forms.View.Details;
            this.playListView.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.playListView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.playListView_ItemDrag);
            this.playListView.VisibleChanged += new System.EventHandler(this.listView1_VisibleChanged);
            this.playListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.playListView_DragDrop);
            this.playListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.playListView_DragEnter);
            this.playListView.DragOver += new System.Windows.Forms.DragEventHandler(this.playListView_DragOver);
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            this.NameCol.Width = 269;
            // 
            // Duration
            // 
            this.Duration.Text = "Duration";
            this.Duration.Width = 68;
            // 
            // playListTools
            // 
            this.playListTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.removeButton,
            this.savePlaylistAs});
            this.playListTools.Location = new System.Drawing.Point(0, 0);
            this.playListTools.Name = "playListTools";
            this.playListTools.Size = new System.Drawing.Size(360, 25);
            this.playListTools.TabIndex = 1;
            this.playListTools.Text = "toolStrip1";
            // 
            // addButton
            // 
            this.addButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addButton.Image = global::Player.icons.plus_icon_32;
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(23, 22);
            this.addButton.Text = "toolStripButton1";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeButton.Image = global::Player.icons.minus_icon_32;
            this.removeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(23, 22);
            this.removeButton.Text = "toolStripButton2";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // savePlaylistAs
            // 
            this.savePlaylistAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.savePlaylistAs.Image = global::Player.icons.save_icon_32;
            this.savePlaylistAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savePlaylistAs.Name = "savePlaylistAs";
            this.savePlaylistAs.Size = new System.Drawing.Size(23, 22);
            this.savePlaylistAs.Text = "toolStripButton3";
            this.savePlaylistAs.ToolTipText = "Save playlist as ...";
            this.savePlaylistAs.Click += new System.EventHandler(this.savePlaylistAs_Click);
            // 
            // PlaylistPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.playListTools);
            this.Controls.Add(this.playListView);
            this.MaximumSize = new System.Drawing.Size(360, 4096);
            this.Name = "PlaylistPanel";
            this.Size = new System.Drawing.Size(360, 326);
            this.Resize += new System.EventHandler(this.UserControl1_Resize);
            this.playListTools.ResumeLayout(false);
            this.playListTools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView playListView;
        private System.Windows.Forms.ToolStrip playListTools;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton removeButton;
        private System.Windows.Forms.ToolStripButton savePlaylistAs;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader Duration;
    }
}
