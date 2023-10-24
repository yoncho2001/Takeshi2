using Microsoft.EntityFrameworkCore;
using Takeshi.Models;

namespace Test.Models;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public DbSet<ArmorProxy> Armors { get; set; } = null!;
    public DbSet<PotionProxy> Potions { get; set; } = null!;
    public DbSet<WeaponProxy> Weapons { get; set; } = null!;
}