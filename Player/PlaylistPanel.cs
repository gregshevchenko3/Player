using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class PlaylistPanel : UserControl
    {
        private BindingList<MediaAdapter> _mediaAdapters;
        private Color prevFore;
        private Color prevBack;
        private ListViewItem prev = null;
        private int _playIndex = -1;
        public int PlayIndex {
            set
            {
                if (_playIndex >= 0)
                { 
                    if (_mode == PlaylistViewMode.DetailForm)
                    {
                        playListView.Items[_playIndex].BackColor = Color.White;
                        playListView.Items[_playIndex].ForeColor = Color.Black;
                    } 
                }
                _playIndex = value;
                if (_mode == PlaylistViewMode.DetailForm)
                {
                    playListView.Items[_playIndex].BackColor = Color.LightGreen;
                    playListView.Items[_playIndex].ForeColor = Color.Green;
                }
                else
                {
                    DropDownPlaylistView.SelectedIndex = _playIndex;
                }
            }
            get => _playIndex;
        }
        public AxWMPLib.AxWindowsMediaPlayer player { get => ((PlayerWindow)Parent).Player ; }
        public bool AllowDropLV {
            get => playListView.AllowDrop;
            set => playListView.AllowDrop = value;
        }
        public bool HideOnTimer { 
            set {
                if(_mode == PlaylistViewMode.DropDownList)
                {
                    Visible = !value;
                }
            } 
        }
        private bool _minimalInterface = false;
        public bool MinimalInterface { 
            get => _minimalInterface; 
            set { 
                if (value)
                {
                    _minimalInterface = value;
                    _mode = PlaylistViewMode.DropDownList;
                    Dock = DockStyle.Top;
                }
            } 
        }
        private PlaylistViewMode _mode;
        public PlaylistViewMode ViewMode {
            set {
                _mode = value;
            }
            get => _mode;
        }
        private ComboBox DropDownPlaylistView;

        public PlaylistPanel()
        {
            InitializeComponent();
            DropDownPlaylistView = new ComboBox();

            _mediaAdapters = new BindingList<MediaAdapter>();
            _mediaAdapters.AllowNew = true;
            _mediaAdapters.AllowRemove = true;
            _mediaAdapters.AllowEdit = false;

            DropDownPlaylistView.DataSource = _mediaAdapters;
            DropDownPlaylistView.DisplayMember = "Name";

            DropDownPlaylistView.DropDown += new System.EventHandler((object sender, System.EventArgs e) => ((PlayerWindow)Parent).TimerLock = true);
            DropDownPlaylistView.DropDownClosed += new System.EventHandler((object sender, System.EventArgs e) => ((PlayerWindow)Parent).TimerLock = false);
            DropDownPlaylistView.SelectedIndexChanged += new System.EventHandler(listView1_ItemActivate);

            DropDownPlaylistView.Visible = false;
            DropDownPlaylistView.Dock = DockStyle.Top;
            Controls.Add(DropDownPlaylistView);
            ViewMode = PlaylistViewMode.DropDownList;
            addButton.ToolTipText = "Add track to playlist";
            removeButton.Enabled = false;
            removeButton.ToolTipText = "Remove selected track";
            savePlaylistAs.Enabled = false;
            savePlaylistAs.ToolTipText = "Save the playlist as ...";
        }
        public void ChangeMode(PlaylistViewMode mode)
        {
            if (mode == PlaylistViewMode.DropDownList)
            {
                playListTools.Visible = false;
                playListView.Visible = false;
                DropDownPlaylistView.Visible = true;
                Height = DropDownPlaylistView.Height;
                DropDownPlaylistView.SelectedIndexChanged -= listView1_ItemActivate;
                DropDownPlaylistView.SelectedIndex = _playIndex;
                DropDownPlaylistView.SelectedIndexChanged += listView1_ItemActivate;
            }
            else
            {
                if (player != null) {
                    Height = player.Height;
                }
                else return;
                
                playListView.Height = Height - playListTools.Height;

                DropDownPlaylistView.Visible = false;
                playListTools.Visible = true;
                playListView.Visible = true;

            }
            _mode = mode;
            
        }

        private bool PlaylistContainsMedia(WMPLib.IWMPPlaylist playlist, WMPLib.IWMPMedia media)
        {
            for (int i = 0; i < playlist.count; i++)
            {
                if (playlist.Item[i].isIdentical[media])
                {
                    return true;
                }
            }
            return false;
        }
        public void AppendInPlaylist(string[] paths, int After = -1, WMPLib.IWMPPlaylist list = null)
        {
            list = (list == null) ? player.currentPlaylist : list;
            foreach (var item in paths)
            {
                FileAttributes attrs = File.GetAttributes(item);
                if ((attrs & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    AppendInPlaylist(Directory.GetFiles(item, "*.*", SearchOption.TopDirectoryOnly), After, list);
                }
                else
                {
                    WMPLib.IWMPMedia media = null;
                    try
                    {
                        media = player.mediaCollection.add(item);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                    if (!PlaylistContainsMedia(list, media))
                    {
                        if (After < 0)
                        {
                            list.appendItem(media);
                            _mediaAdapters.Add(new MediaAdapter(media));
                        }
                        else
                        {
                            list.insertItem(++After, media);
                            _mediaAdapters.Insert(After, new MediaAdapter(media));
                        }
                    }
                }
            }
        }
        private void listView1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                playListView.Items.Clear();
                foreach (var item in _mediaAdapters)
                {
                    ListViewItem lvi = new ListViewItem(item.Name);
                    lvi.SubItems.Add(item.Duration);
                    playListView.Items.Add(lvi);
                }
                if (_playIndex >= 0)
                {
                    playListView.Items[_playIndex].BackColor = Color.LightGreen;
                    playListView.Items[_playIndex].ForeColor = Color.Green;
                }
                if(playListView.Items.Count > 0)
                {
                    removeButton.Enabled = true;
                    savePlaylistAs.Enabled = true;
                }
            }
        }
        private void UserControl1_Resize(object sender, EventArgs e)
        {
            playListView.Top = playListTools.Height;
            playListView.Height = Height - playListTools.Height;

            playListView.Left = 2;
            playListView.Width = Width - 4;

            playListView.Columns[0].Width = playListView.Width - 60;
            playListView.Columns[1].Width = 60;
        }
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if(_mode == PlaylistViewMode.DetailForm)
               PlayIndex = playListView.SelectedItems[0].Index;
            else 
               PlayIndex = DropDownPlaylistView.SelectedIndex;
            player.Ctlcontrols.playItem(player.currentPlaylist.Item[_playIndex]);
        }
        private void playListView_DragOver(object sender, DragEventArgs e)
        {
            var point = playListView.PointToClient(new Point(e.X, e.Y));
            var item = playListView.GetItemAt(point.X, point.Y);
            if (item != null && item != prev)
            {
                if (prev != null) {
                    prev.BackColor = prevBack;
                    prev.ForeColor = prevFore;
                    prev.Checked = false;
                }
                prev = item;
                prevBack = item.BackColor;
                prevFore = item.ForeColor;
                
                item.BackColor = Color.LightGray;
                item.ForeColor = Color.Gray;
                item.Checked = true;
            }
        }
        private void playListView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                Visible = false;
                AppendInPlaylist(data, playListView.CheckedItems[0].Index);
                Visible = true;
            }
            else if(e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem moved = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                player.currentPlaylist.moveItem(moved.Index, playListView.CheckedItems[0].Index);
                
                if(playListView.CheckedItems[0].Index + 1 > moved.Index)
                {
                    _mediaAdapters.Insert(playListView.CheckedItems[0].Index + 1, _mediaAdapters[moved.Index]);
                    _mediaAdapters.RemoveAt(moved.Index);
                } 
                else
                {
                    MediaAdapter adapter = _mediaAdapters[moved.Index];
                    _mediaAdapters.RemoveAt(moved.Index);
                    _mediaAdapters.Insert(playListView.CheckedItems[0].Index, adapter);
                }
                
                playListView.Visible = false;
                playListView.Visible = true;
                MessageBox.Show($"playing index: {_playIndex} ;");
            }
        }
        private void playListView_DragEnter(object sender, DragEventArgs e)
        {
            if (playListView.Items.Count == 0)
            {
                Visible = false;
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                    AppendInPlaylist(data);
                }
                Visible = true;

            }
                e.Effect = DragDropEffects.Move;
        }
        private void addButton_Click(object sender, EventArgs e)
        {

        }
        private void playListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
    }
}
