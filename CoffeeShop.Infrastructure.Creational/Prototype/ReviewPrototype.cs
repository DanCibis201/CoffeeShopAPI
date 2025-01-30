//using CoffeeShop.Database.SqlServer.Entities;

//namespace CoffeeShop.Infrastructure.Creational.Prototype;

//public class ReviewPrototype
//{
//    private readonly Review? _prototype;

//    public ReviewPrototype(Review? prototype)
//    {
//        _prototype = prototype;
//    }

//    public Review Clone()
//    {
//        if (_prototype == null)
//        {
//            throw new InvalidOperationException("Prototype is not set.");
//        }

//        return new Review
//        {
//            Id = Guid.NewGuid(),
//            CoffeeId = _prototype.CoffeeId,
//            UserName = _prototype.UserName,
//            Comment = _prototype.Comment,
//            Rating = _prototype.Rating
//        };
//    }

//    public Review CreateNewReview(string userName, string comment, int rating, Guid coffeeId)
//    {
//        return new Review
//        {
//            Id = Guid.NewGuid(),
//            UserName = userName,
//            Comment = comment,
//            Rating = rating,
//            CoffeeId = coffeeId
//        };
//    }
//}