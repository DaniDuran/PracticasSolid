using Microsoft.EntityFrameworkCore;
using ms_regis.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_regis.infraestructuraPostgreSQL.Context
{
    public class SystemContextPostgres: DbContext
    {
        public SystemContextPostgres()
        {
                
        }

        public SystemContextPostgres(DbContextOptions<SystemContextPostgres> dbContextOptions)
        : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString: "server=localhost; port=5432; user id= admin; password=admin; database= system-lab; commandtimeout= 1024; timeout=300;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LoginRecord> LoginRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { 
                entity.ToTable("users","system-lab");
                entity.Property(f => f.Id).HasColumnName("id").HasComment("llave primaria");
                entity.Property(f => f.Name).HasColumnName("name").HasComment("Campo nombre");
                entity.Property(f => f.LastName).HasColumnName("lastname")
                                                .HasComment("Campo apellido");
                entity.Property(f => f.Email).HasColumnName("email")
                                             .HasComment("Campo email de tipo unico");                
                entity.Property(f => f.Password).HasColumnName("password")
                                                .HasComment("Campo clave");
                entity.Property(f => f.BirthDate).HasColumnName("birthdate")
                                                 .HasComment("Campo nombre")
                                                 .HasColumnType("timestamp without time zone");
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
                entity.Property(f=> f.Id).HasColumnName("id");
                entity.Property(f=> f.Date).HasColumnName("date");
                entity.Property(f=> f.Access).HasColumnName("access");
                entity.Property(f=> f.IdUser).HasColumnName("iduser");                
            });
        }


    }
}
