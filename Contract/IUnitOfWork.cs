namespace UNIT_OF_WORK.Contract
{
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }
        Task CompleteAsync();
    }
}
