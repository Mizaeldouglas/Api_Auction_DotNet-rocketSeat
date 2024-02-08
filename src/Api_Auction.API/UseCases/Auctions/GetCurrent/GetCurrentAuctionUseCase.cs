using Api_Auction.API.Entities;
using Api_Auction.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api_Auction.API.UseCases.Actions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repository = new ApiAuctionDbContext();
        var today = DateTime.Now;
        
        return repository
            .Auctions
            .Include(a => a.Items)
            .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
    }
}