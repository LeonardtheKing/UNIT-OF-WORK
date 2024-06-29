using UNIT_OF_WORK.Contract;
using UNIT_OF_WORK.Repositories;

namespace UNIT_OF_WORK.Data;

public class UnitOfWork : IUnitOfWork,IDisposable
{
    private readonly ApiDbContext _context;
  
   
    public IDriverRepository Drivers { get; private set; }

    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
     

        Drivers = new DriverRepository(context);
    }
    public async Task CompleteAsync()
    {
      await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
