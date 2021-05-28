using System.Collections.Generic;

namespace Cosmic.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public byte[] Avatar { get; set; }
        public string AboutUser { get; set; }
        public bool IsBlocked { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
