﻿using System;
using Microsoft.EntityFrameworkCore;
using Trainingcenter.Domain.DomainModels;

namespace Tradingcenter.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ExchangeKey> ExchangeKeys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<PortfolioComment> PortfolioComments { get; set; }
        public DbSet<OrderComment> OrderComments { get; set; }
        public DbSet<PortfolioOrder> OrderPortolios { get; set; }
        public DbSet<Wallet> Transactions { get; set; }
        public DbSet<PurchasedPortfolio> PurchasedPortfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioOrder>()
                .HasKey(op => new { op.OrderId, op.PortfolioId });

            modelBuilder.Entity<PortfolioOrder>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderPortfolios)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<PortfolioOrder>()
                .HasOne(op => op.Portfolio)
                .WithMany(p => p.PortfolioOrders)
                .HasForeignKey(op => op.PortfolioId);
        }
    }
}
