using Api_Auction.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_Auction.API.Repositories;

public class ApiAuctionDbContext : DbContext
{
    public DbSet<Auction> Auctions { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(
            @"Data Source=/Users/mizaeldouglasmello/Programação/WorkSpace-DotNet/NLW/Api_Auction/src/Api_Auction.API/leilaoDbNLW.db");
    }
}