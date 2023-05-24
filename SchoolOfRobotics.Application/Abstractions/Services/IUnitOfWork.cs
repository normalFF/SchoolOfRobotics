namespace SchoolOfRobotics.Application.Abstractions.Services
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
