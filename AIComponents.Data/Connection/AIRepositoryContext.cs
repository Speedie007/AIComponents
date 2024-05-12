using AIComponents.Data.Domain;
using AIComponents.Data.Domain.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.Data.Connection
{

    public partial class AIRepositoryContext : DbContext
    {

        public AIRepositoryContext(DbContextOptions<AIRepositoryContext> options)
        : base(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=Password!;Persist Security Info=True;User ID=sa;Initial Catalog=AIComponentsDB_01_05_2024;Data Source=.;Trust Server Certificate=True;");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //base.ConfigureConventions(configurationBuilder);

        }
    }
}
