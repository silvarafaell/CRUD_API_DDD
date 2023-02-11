using CRUD.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class FactoryContext : DbContext
    {
        public FactoryContext(DbContextOptions<FactoryContext> options) : base(options)
        { }

        public virtual DbSet<Empregado> Empregado { get; set; }
    }
}
