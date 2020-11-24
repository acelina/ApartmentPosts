using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApartmentPosts.Models;

namespace ApartmentPosts.Data
{
    public class ApartmentPostsContext : DbContext
    {
        public ApartmentPostsContext (DbContextOptions<ApartmentPostsContext> options)
            : base(options)
        {
        }

        public DbSet<ApartmentPosts.Models.ApartmentPost> ApartmentPost { get; set; }
    }
}
