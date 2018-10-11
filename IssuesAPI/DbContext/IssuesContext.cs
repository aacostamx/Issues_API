using IssuesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssuesAPI
{
    public class IssuesContext : DbContext
    {
        public IssuesContext(DbContextOptions<IssuesContext> options) : base(options) { }

        public virtual void Save()
        {
            base.SaveChanges();
        }

        public DbSet<Issues> Issues { get; set; }
    }
}
