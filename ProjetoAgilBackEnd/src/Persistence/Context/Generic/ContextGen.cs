using Microsoft.EntityFrameworkCore;

namespace Persistence.Context.Generic
{
    public abstract class ContextGen : DbContext
    {
        public ContextGen(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}