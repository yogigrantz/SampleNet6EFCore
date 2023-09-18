using Microsoft.EntityFrameworkCore;

namespace TestEFCore.Test;

public class TestContext : DbContext
{
    private string _connStr = "server=(localdb)\\MSSQLLocalDB;database=EFCoreTest;Integrated Security=SSPI";

    public TestContext()
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder option)
    {
        option.UseSqlServer(_connStr);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        EFTestDBInitializer dbi = new EFTestDBInitializer(builder);
        dbi.Seed();
    }

    public TestContext(DbContextOptions<TestContext> options) : base(options)
    {
    }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Client> Clients { get; set; }
}
