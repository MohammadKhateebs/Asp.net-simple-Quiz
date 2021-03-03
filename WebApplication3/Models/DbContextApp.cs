using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class DbContextApp:DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp>options):base(options) {

        }
        public DbSet<Quiz>QuizQUS { get; set; }
        public DbSet<User> Table { get; set; }


    }
}
