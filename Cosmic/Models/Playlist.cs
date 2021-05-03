using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmic.Models
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public byte[] Avatar { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Music> Musics { get; set; }
    }
}
