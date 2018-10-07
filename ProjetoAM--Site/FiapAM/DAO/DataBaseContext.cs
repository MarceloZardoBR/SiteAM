using FiapAM.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace FiapAM.DAO
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=OracleDbContext")
        {
            Database.SetInitializer<DataBaseContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("RM76355");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<TipoContato> TipoContato { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Investidor> Investidor { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        
    }
}