using Api_Auction.API.Communications.Requests;
using Api_Auction.API.Entities;
using Api_Auction.API.Repositories;
using Api_Auction.API.Services;
using Microsoft.EntityFrameworkCore;

namespace Api_Auction.API.UseCases.Offers.CreateOffers;

public class CreateOfferUseCase
{
    private readonly LoggedUser _loggedUser;

    public CreateOfferUseCase(LoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
    }
    public int Execute(int itemId, RequestCreateOfferJson request)
    {
        var repository = new ApiAuctionDbContext();
        var loggedUser = _loggedUser.User();
        var offer = new Offer
        {
            CreatedOn = DateTime.Now,
            ItemId = itemId,
            Price = request.Price,
            UserId = loggedUser.Id
        };
        repository.Offers.Add(offer);
        repository.SaveChanges();
        
        return offer.Id;

    }
}