﻿using API.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiDeveloperSkillTestProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<ProductModel> products { get; set; }
    }
}
