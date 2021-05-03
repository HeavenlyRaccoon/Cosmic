using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
