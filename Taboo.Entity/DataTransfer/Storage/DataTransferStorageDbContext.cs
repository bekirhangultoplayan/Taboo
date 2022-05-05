using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Taboo.Entity.DataTransfer.Storage
{
    public class DataTransferStorageDbContext : DbContext
    {
        public DataTransferStorageDbContext(DbContextOptions<DataTransferStorageDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<WordStorageEntity> TBL_Word { get; set; }
        public DbSet<ForbiddenWordStorageEntity> TBL_ForbiddenWord { get; set; }
        public DbSet<GameStorageEntity> TBL_Game  { get; set; }
        public DbSet<OutWordStorageEntity> TBL_OutWord { get; set; }





    }
}
