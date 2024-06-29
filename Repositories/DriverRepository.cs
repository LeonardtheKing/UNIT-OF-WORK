using UNIT_OF_WORK.Contract;
using UNIT_OF_WORK.Data;
using UNIT_OF_WORK.Models;

namespace UNIT_OF_WORK.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ApiDbContext context) : base(context)
    {

    }

   public override async Task<IEnumerable<Driver>> GetAllAsync()
    {       
            return _dbContext.Drivers.ToList();

    }

    public async Task<Driver?> GetDriverNumber(int driverNumber)
    {

            return _dbContext.Drivers.FirstOrDefault(x=> x.DriverNumber == driverNumber);
    }
}
