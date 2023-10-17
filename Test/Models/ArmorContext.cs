using Microsoft.EntityFrameworkCore;

namespace Test.Models;

public class ArmorContext : DbContext
{
    public ArmorContext(DbContextOptions<ArmorContext> options)
        : base(options)
    {
    }

    public DbSet<Armor> Armors { get; set; } = null!;
}