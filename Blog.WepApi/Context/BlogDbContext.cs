using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.WepApi.Context
{
    public class BlogDbContext: DbContext
    {
        //Db konfügrasyonunu yaptığımız yer.
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }
        
        //tabloların hangi şemada olduğunu bu şekilde anlıyoruz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Main"); //Bu main şemasını kullandığımı anlamına geliyor, Postgrede şema ile çalıştıl
        }

        //Db tablolarının classlar ile eşleştiği kısım
        public DbSet<Entity.User> User { get; set; } 
        public DbSet<Entity.Category> Category { get; set; }
        public DbSet<Entity.Post> Post { get; set; }
        public DbSet<Entity.Comments> Comments { get; set; }
    }
}
