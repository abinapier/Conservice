using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConserviceHRSite.Models;

    public class ConserviceTeam : DbContext
    {
        public ConserviceTeam (DbContextOptions<ConserviceTeam> options)
            : base(options)
        {
        }

        public DbSet<ConserviceHRSite.Models.Employee> Employee { get; set; }

        public DbSet<ConserviceHRSite.Models.Department> Department { get; set; }

        public DbSet<ConserviceHRSite.Models.Position> Position { get; set; }

        public DbSet<ConserviceHRSite.Models.Changes> Changes { get; set; }
    }
