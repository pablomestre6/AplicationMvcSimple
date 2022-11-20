using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AplicationMvcSimple.Models;

namespace AplicationMvcSimple.Data
{
    public class AplicationMvcSimpleContext : DbContext
    {
        public AplicationMvcSimpleContext (DbContextOptions<AplicationMvcSimpleContext> options)
            : base(options)
        {
        }

        public DbSet<AplicationMvcSimple.Models.SchoolModel> SchoolModel { get; set; } = default!;

        public DbSet<AplicationMvcSimple.Models.Studentes> Studentes { get; set; }
    }
}
