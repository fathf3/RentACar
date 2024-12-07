using RentACar.Domain.Entities;

namespace RentACar.Application.Interfaces
{
    public interface IFeatureRepository : IRepository<Feature>
    {
        int Count();
    }
}
