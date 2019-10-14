namespace Timelogger.Api.Repository
{
    public interface IRepositoryWrapper
    {
        IUsersRepository UserRepository { get; }
        IProjectsRepository ProjectRepository { get; }
        IActivityRepository ActivityRepository { get; }
        bool PersistDbChanges();
    }
}