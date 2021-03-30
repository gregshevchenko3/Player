using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player
{
    public class MediaAdapter
    {
        private WMPLib.IWMPMedia _media;

        public string Name
        {
            get
            {
                return _media.name;
            }
        }
        public string Duration
        {
            get
            {
                return _media.durationString;
            }
        }
        public MediaAdapter(WMPLib.IWMPMedia wMPMedia)
        {
            _media = wMPMedia;
        }
    }
}
