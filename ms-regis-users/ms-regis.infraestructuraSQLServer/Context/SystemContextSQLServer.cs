using Microsoft.EntityFrameworkCore;
using ms_regis.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_regis.infraestructuraSQLServer.Context
{
    public class SystemContextSQLServer: DbContext
    {
        public SystemContextSQLServer()
        {
                
        }

        public SystemContextSQLServer(DbContextOptions<SystemContextSQLServer> dbContextOptions)
        : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "server=localhost,1433; user id= admin; password=admin1234*; database= system-lab;timeout=300;TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LoginRecord> LoginRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { 
                entity.ToTable("users","system-lab");
                entity.Property(f=>f.Id);
                entity.Property(f => f.Name);
                entity.Property(f => f.LastName);
                entity.Property(f => f.Email);
                entity.Property(f => f.Password);
                entity.Property(f => f.BirthDate);                                                 
                entity
                      .HasMany(e => e.LoginRecords)
                      .WithOne(l =>l.User)
                      .HasForeignKey(l=> l.IdUser)
                      .HasPrincipalKey(e=> e.Id);
                entity.HasIndex(f=> f.Email).IsUnique();
                entity.HasIndex(f=> new { f.Name, f.LastName});                                   
            });
            modelBuilder.Entity<LoginRecord>(entity => { 
                entity.ToTable("loginrecords", "system-lab");
                entity.Property(f=> f.Id);
                entity.Property(f => f.Date);
                entity.Property(f => f.Access);
                entity.Property(f => f.IdUser);
            });
        }
    }
}
