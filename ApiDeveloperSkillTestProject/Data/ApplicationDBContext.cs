using API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PacificKnitDivisionWebPortal.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<ProductModel> products { get; set; }

    }
}
