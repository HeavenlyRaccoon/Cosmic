using System.Data.Entity;

namespace Cosmic.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext():base("DbConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Music> Musics { get; set; }
    }
}
