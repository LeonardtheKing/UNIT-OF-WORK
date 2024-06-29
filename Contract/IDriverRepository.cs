using UNIT_OF_WORK.Models;

namespace UNIT_OF_WORK.Contract
{
    public interface IDriverRepository:IGenericRepository<Driver>
    {
        Task<Driver?> GetDriverNumber(int driverNumber);
    }
}
