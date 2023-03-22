using Microsoft.EntityFrameworkCore;

namespace gwent_patch_info.Models;

public class PatchDataContext : DbContext
{
  public PatchDataContext(DbContextOptions<PatchDataContext> options): base(options)
    {
    }
    public DbSet<Card> Cards { get; set; } = null!;
}