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
    public partial class ListPlaylists : Form
    {
        public ListPlaylists()
        {
            InitializeComponent();
        }
        public WMPLib.IWMPPlaylistCollection Col { set; get; }
        public Button OkBtn { get => OpenButton; }
        public WMPLib.IWMPPlaylist wMPPlaylist { get; private set; }
        private void ListPlaylists_Load(object sender, EventArgs e)
        {
            WMPLib.IWMPPlaylistArray array = Col.getAll();
            for (int i = 0; i < array.count; i++) {
                listView1.Items.Add(array.Item(i).name);
            }
        }
        private void OpenButton_Click(object sender, EventArgs e)
        {
            wMPPlaylist = Col.getByName(listView1.SelectedItems[0].Text).Item(0);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            OpenButton.Enabled = listView1.SelectedItems.Count > 0;
        }
    }
}
