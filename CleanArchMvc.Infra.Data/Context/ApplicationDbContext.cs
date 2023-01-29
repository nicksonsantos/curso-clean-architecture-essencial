using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        // com a linha acima evitamos ter que aplicar a configuracão para cada entidade
        // senao seria necessario utilizar:
        // builder.ApplyConfiguration(new CategoryConfiguration());
        // builder.ApplyConfiguration(new ProductConfiguration());

    }
}