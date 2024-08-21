namespace Shopping.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}