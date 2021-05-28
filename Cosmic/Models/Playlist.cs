using System.Collections.Generic;

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
