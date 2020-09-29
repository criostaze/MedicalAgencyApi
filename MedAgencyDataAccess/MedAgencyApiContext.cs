using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedAgencyApi.Models;
using System.ComponentModel.DataAnnotations;
using MedAgencyApi.Data.Interfaces;

namespace MedAgencyApi.Data
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
