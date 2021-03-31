using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Player
{
    public partial class PlayerWindow : Form
    {
        private string _arg = "";
        private int _fx = 0, _fy = 0;
        private int _dx, _dy, playlist_position = 0;
        private InterfaceSettings _settings;
        public AxWMPLib.AxWindowsMediaPlayer Player { get => player;  }
        public int PlayerHeight { get => Height - menuStrip1.Height; }
        public bool TimerLock { 
            set {
                HideDropDownPlayListTimer.Enabled = !value;
            } 
        }
        public PlayerWindow(string arg)
        {
            InitializeComponent();
            
            _arg = arg;
            _settings = new InterfaceSettings();
            playlistPanel1.Top = player.Top;
        }
        private void PlayerWindow_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_arg))
            {
                playlistPanel1.AppendInPlaylist(new string[] { _arg });
            }
            if (File.Exists("settings.set"))
            {
                Stream stream = File.Open("settings.set", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                _settings = (InterfaceSettings)formatter.Deserialize(stream);
                stream.Close();
            }
            player.Dock = DockStyle.Fill;
            player.Width = this.Width;
            player.Height = this.Height;
            alwaysOnTopToolStripMenuItem.Checked = minimalInterfaceToolStripMenuItem.Checked = false;
            minimalInterfaceToolStripMenuItem.Checked = _settings.MinimalInterface;
            alwaysOnTopToolStripMenuItem.Checked = _settings.AlwaysOnTop;
            dropdownListToolStripMenuItem.Checked = (_settings.PlaylistViewMode == PlaylistViewMode.DropDownList);
            leftPanelToolStripMenuItem.Checked = (_settings.PlaylistViewMode == PlaylistViewMode.DetailForm);

            playlist_position = playlistToolStripMenuItem.DropDown.Items.Count;
            change_playlistmenu_items();
        }
        private void ChangePlaylist(object sender, EventArgs e)
        {
            WMPLib.IWMPPlaylistArray array = player.playlistCollection.getByName(((ToolStripMenuItem)sender).Text);
            if(array.count > 0) { 
                player.currentPlaylist = array.Item(0);
                playlistPanel1.LoadFromPlayList();
            }
        }
        private void PlayerWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (_settings.PlaylistViewMode == PlaylistViewMode.DetailForm)
                    playlistPanel1.Visible = false;
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                playlistPanel1.AppendInPlaylist(data);
                if (_settings.PlaylistViewMode == PlaylistViewMode.DetailForm)
                    playlistPanel1.Visible = true;
            }
        }
        private void PlayerWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.MinimalInterface = minimalInterfaceToolStripMenuItem.Checked;
            _settings.AlwaysOnTop = alwaysOnTopToolStripMenuItem.Checked;
            _settings.PlaylistViewMode = playlistPanel1.ViewMode;

            Stream stream = File.Open("settings.set", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, _settings);
            stream.Close();
        }
        private void PlayerWindow_Resize(object sender, EventArgs e)
        {
            playlistPanel1.Width = Width / 2;
            playlistPanel1.Left = Width - playlistPanel1.Width - 18;
            if (playlistPanel1.ViewMode == PlaylistViewMode.DetailForm)
            {
                playlistPanel1.Height = Height;
                player.Width = Width - playlistPanel1.Width - 20;
                player.Dock = DockStyle.Left;
            }
            else
            {
                player.Dock = DockStyle.Fill;
            }
        }
        private void Player_CurrentPlaylistChange(object sender, AxWMPLib._WMPOCXEvents_CurrentPlaylistChangeEvent e)
        {
            // Якщо змінився плейлист, але нічого не відтворюється
            if (player.playState == WMPLib.WMPPlayState.wmppsReady)
            {
                // Почати відтворення першого треку в списку.
                playlistPanel1.PlayIndex = 0;
                player.Ctlcontrols.playItem(player.currentPlaylist.Item[0]);
            }
            if(e.change == WMPLib.WMPPlaylistChangeEventType.wmplcInsert || e.change == WMPLib.WMPPlaylistChangeEventType.wmplcMove)
            {
                for (int i = 0; i < player.currentPlaylist.count; i++)
                {
                    if (player.currentPlaylist.Item[i].isIdentical[player.currentMedia])
                    {
                        if(playlistPanel1.Count > 0 )
                            playlistPanel1.PlayIndex = i;
                        break;
                    }
                }
            }
        }
        private void Player_CurrentItemChange(object sender, AxWMPLib._WMPOCXEvents_CurrentItemChangeEvent e)
        {
            // Синхронізація контролів плеєра з плейлистом.
            for (int i = 0; i < player.currentPlaylist.count; i++)
            {
                if (player.currentPlaylist.Item[i].isIdentical[(WMPLib.IWMPMedia)e.pdispMedia])
                {
                    playlistPanel1.PlayIndex = i;
                    break;
                }
            }
        }
        private void Player_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
            // Відображення плейлисту в режимі випадаючого списку по переміщеню мишки.
            if (_fx != e.fX || _fy != e.fY)
            {
                playlistPanel1.HideOnTimer = false;
                if (minimalInterfaceToolStripMenuItem.Checked)
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                HideDropDownPlayListTimer.Enabled = true;
                _fx = e.fX;
                _fy = e.fY;
            }
        }
        private void HideDropDownPlayListTimer_Tick(object sender, EventArgs e)
        {
            playlistPanel1.HideOnTimer = true;
            if (minimalInterfaceToolStripMenuItem.Checked)
                this.FormBorderStyle = FormBorderStyle.None;
        }
        private void minimalInterfaceToolStripMenuItem_Click(object sender, EventArgs e) => ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e) => ((ToolStripMenuItem)sender).Checked = !((ToolStripMenuItem)sender).Checked;
        private void alwaysOnTopToolStripMenuItem_CheckedChanged(object sender, EventArgs e) => TopMost = ((ToolStripMenuItem)sender).Checked;
        private void dropdownListToolStripMenuItem_Click(object sender, EventArgs e)
        {

            leftPanelToolStripMenuItem.Checked = dropdownListToolStripMenuItem.Checked;
            dropdownListToolStripMenuItem.Checked = !dropdownListToolStripMenuItem.Checked;
            if (playlistPanel1.ViewMode == PlaylistViewMode.DropDownList || playlistPanel1.MinimalInterface)
            {
                HideDropDownPlayListTimer.Enabled = true;
            }
        }
        private void leftPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dropdownListToolStripMenuItem.Checked = leftPanelToolStripMenuItem.Checked;
            leftPanelToolStripMenuItem.Checked = !leftPanelToolStripMenuItem.Checked;
        }
        private void leftPanelToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                playlistPanel1.ChangeMode(PlaylistViewMode.DetailForm);
                player.Dock = DockStyle.Left;
                player.Width = Width - playlistPanel1.Width - 20;
                playlistPanel1.Visible = true;
                AllowDrop = false;
                playlistPanel1.AllowDropLV = true;
            }
        }
        private void dropdownListToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Checked)
            {
                playlistPanel1.ChangeMode(PlaylistViewMode.DropDownList);
                player.Dock = DockStyle.None;
                player.Width = Width;
                AllowDrop = true;
                playlistPanel1.AllowDropLV = false;
            }
        }
        private void DeletePlaylist_Click(object sender, EventArgs e)
        {
            ListPlaylists listPlaylists = new ListPlaylists();
            listPlaylists.Text = "Delete playlist";
            listPlaylists.OkBtn.Text = "Delete";
            listPlaylists.Col = player.playlistCollection;
            if (listPlaylists.ShowDialog() == DialogResult.OK)
            {
                player.playlistCollection.remove(listPlaylists.wMPPlaylist);
                for (int i = playlist_position; i < playlistToolStripMenuItem.DropDown.Items.Count; i++)
                {
                    if (playlistToolStripMenuItem.DropDown.Items[i].Text == listPlaylists.wMPPlaylist.name)
                    {
                        playlistToolStripMenuItem.DropDown.Items.Remove(playlistToolStripMenuItem.DropDown.Items[i]);
                    }
                }
            }
        }
        public void change_playlistmenu_items()
        {
            if(playlistToolStripMenuItem.DropDown.Items.Count - playlist_position < 10)
            {
                WMPLib.IWMPPlaylistArray array = player.playlistCollection.getAll();
                for (int i = 0; i < array.count && i < 10; i++)
                {
                    playlistToolStripMenuItem.DropDown.Items.Add(array.Item(i).name).Click += ChangePlaylist;
                }
            }
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            player.currentPlaylist.clear();
            playlistPanel1.Clear();
        }

        private void OpenPlaylist_Click(object sender, EventArgs e)
        {
            ListPlaylists listPlaylists = new ListPlaylists();
            listPlaylists.Text = "Open playlist";
            listPlaylists.OkBtn.Text = "Open";
            listPlaylists.Col = player.playlistCollection;
            if (listPlaylists.ShowDialog() == DialogResult.OK) {
                MessageBox.Show(listPlaylists.wMPPlaylist.name);
                player.currentPlaylist = listPlaylists.wMPPlaylist;
                playlistPanel1.LoadFromPlayList();
            }
        }
        private void player_KeyUpEvent(object sender, AxWMPLib._WMPOCXEvents_KeyUpEvent e)
        {
            if (e.nKeyCode == 27 && minimalInterfaceToolStripMenuItem.Checked)
            {
                minimalInterfaceToolStripMenuItem.Checked = false;
            }
        }
        private void minimalInterfaceToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            _settings.MinimalInterface = ((ToolStripMenuItem)sender).Checked;
            if (_settings.MinimalInterface)
            {
                menuStrip1.Visible = false;
                player.uiMode = "none";
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                HideDropDownPlayListTimer.Enabled = true;
                playlistPanel1.ViewMode = PlaylistViewMode.DropDownList;
                AllowDrop = true;
            } 
            else
            {
                player.Dock = DockStyle.Fill;
                player.uiMode = "full";
                FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                playlistPanel1.ViewMode = PlaylistViewMode.DropDownList;
                menuStrip1.Visible = true;
            }
        }
    }
}
