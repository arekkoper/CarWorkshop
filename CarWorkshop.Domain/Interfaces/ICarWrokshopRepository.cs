
namespace CarWorkshop.Domain.Interfaces
{
    public interface ICarWrokshopRepository
    {
        Task Create(Domain.Entities.CarWorkshop carWorkshop);

    }
}
