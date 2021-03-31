using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player
{
    public partial class playlistSaveAs : Form
    {
        private AxWMPLib.AxWindowsMediaPlayer _player;
        public playlistSaveAs(AxWMPLib.AxWindowsMediaPlayer player)
        {
            InitializeComponent();
            _player = player;
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var pl_name = NameBox.Text.Trim();
            WMPLib.IWMPPlaylistArray playlists = _player.playlistCollection.getAll();
            if (playlists != null && playlists.count > 0)
            {
                int exists = -1;
                for (int i = 0; i < playlists.count; i++)
                {
                    try
                    {
                        if (!_player.playlistCollection.isDeleted(playlists.Item(i)) && playlists.Item(i).name == pl_name)
                        {
                            exists = i;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (exists >= 0) {
                    if (MessageBox.Show("The playlist with this name already exists. Overwrite it?",
                        "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _player.playlistCollection.remove(playlists.Item(exists));
                    }
                    else
                        return;
                }
            }
            WMPLib.IWMPPlaylist new_playlist = _player.playlistCollection.newPlaylist(pl_name);
            for(int i = 0; i < _player.currentPlaylist.count; i++)
            {
                new_playlist.appendItem(_player.currentPlaylist.Item[i]);
            }
            Close();
        }
        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            SaveBtn.Enabled = NameBox.TextLength != 0;
        }
    }
}
