using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public enum PlaylistViewMode
    {
        DropDownList,
        DetailForm,
    }
    [Serializable]
    class InterfaceSettings
    {
        public bool MinimalInterface { get; set; } = false;
        public bool AlwaysOnTop { get; set; } = false;
        public PlaylistViewMode PlaylistViewMode { get; set; } = PlaylistViewMode.DropDownList;
    }
}
