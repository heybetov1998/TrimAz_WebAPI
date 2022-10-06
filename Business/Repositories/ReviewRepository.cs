using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Exceptions.EntityExceptions;

namespace Business.Repositories;

public class ReviewRepository : IReviewService
{
    private readonly IReviewDAL _reviewDAL;

    public ReviewRepository(IReviewDAL reviewDAL)
    {
        _reviewDAL = reviewDAL;
    }

    public Task<Review> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Review>> GetAllAsync(int take = int.MaxValue)
    {
        var datas = await _reviewDAL.GetAllAsync(
            expression: n => !n.IsDeleted,
            includes: new string[] { "User" });

        if (datas is null)
        {
            throw new EntityCouldNotFoundException();
        }

        return datas;
    }

    public Task CreateAsync(Review entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, Review entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
