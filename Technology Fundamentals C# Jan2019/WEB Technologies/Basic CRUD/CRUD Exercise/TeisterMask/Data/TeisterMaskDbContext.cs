using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TeisterMask.Models; // we make sure this is set

namespace TeisterMask.Data
{
    //SECOND THING TO DO IS DB CONTEXT TO MAKE THE MODEL INTO THE DATABASE
    public class TeisterMaskDbContext : DbContext
    {
        //give name of the model call -> "Task"
        public DbSet<Task> Tasks { get; set; }

        private const string ConnectionString = @"Server=.\SQLExpress;Database=TeisterMaskDb;Integrated Security = true;";
        //override on + SPACE + ENTER
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
// FINALLY MAKE MIGRATION
