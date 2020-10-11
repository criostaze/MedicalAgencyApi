using MedAgencyApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedAgencyDataAccess.Data
{
	public class MedAgencyApiContext : DbContext
    {
        public MedAgencyApiContext (DbContextOptions<MedAgencyApiContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Card> Card { get; set; }
    }
}
