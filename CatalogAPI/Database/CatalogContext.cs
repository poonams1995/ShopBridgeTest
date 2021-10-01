using CatalogAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace CatalogAPI.Database
{
    /// <summary>
    /// Class for creating Tables by using Entity framework core DbContext and Dbset class
    /// </summary>
    public class CatalogContext:DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options):base(options)
        {

        }
        public DbSet<Catalog> Catalogs { get; set; } 
        public DbSet<Category> Categories { get; set; } 
        public DbSet<UnitMaster> UnitMaster { get; set; } 
        public DbSet<CatalogAttachments> CatalogAttachments { get; set; } 
        public DbSet<CategoryAttachments> CategoryAttachments { get; set; }

       
    }
}
