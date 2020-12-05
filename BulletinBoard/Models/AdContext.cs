using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BulletinBoard.Models
{
    public class AdContext : DbContext
    {
        public DbSet<Ad> Ads { get; set; }
    }
}