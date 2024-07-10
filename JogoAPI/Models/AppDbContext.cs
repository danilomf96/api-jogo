using JogoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Personagem> Personagens { get; set; }
    public DbSet<Vilao> Viloes { get; set; }

    //override OnConfiguring
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=heroworld.db");
    }
}