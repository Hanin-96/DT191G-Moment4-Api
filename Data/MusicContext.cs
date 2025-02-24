using Music_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Music_Api.Data
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options): base(options) { }

        //Tabeller
        public DbSet<Soundtrack> Soundtrack { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
