﻿namespace P03_FootballBetting.Data
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext: DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity
                    
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity


            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity


            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity


            });

            //TODO


        }
    }
}
