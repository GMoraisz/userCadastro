using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices.ObjectiveC;
using System.Security.Cryptography.X509Certificates;
using UserCadastro.Models;

namespace UserCadastro.Data
{
    public class SystemUserRegistersDBContext: DbContext
    {

        public SystemUserRegistersDBContext(DbContextOptions<SystemUserRegistersDBContext> options)
        : base(options)
        {
        }
            public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            base.OnModelCreating(modelBuilder);
        }
        
        
                
        }
    }

