using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmic.Models
{
    public class Music
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string TrackTime { get; set; }
        public byte[] ImgData { get; set; }
        public string MusicSource { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
