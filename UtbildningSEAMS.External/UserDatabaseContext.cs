using Microsoft.EntityFrameworkCore;
using UtbildningSEAMS.Business.Domain;

namespace UtbildningSEAMS.External;

public class UserDatabaseContext(DbContextOptions<UserDatabaseContext> options) : DbContext(options)
{
    public DbSet<City> Cities { get; set; }
}