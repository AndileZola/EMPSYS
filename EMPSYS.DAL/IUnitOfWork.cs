using EMPSYS.DAL.Context;

namespace EMPSYS.DAL
{
    public interface IUnitOfWork
    {
        BaseRepository<Employee> InEmployees { get; }
        BaseRepository<Task> InTasks { get; }
        BaseRepository<Role> InRoles { get; }
        BaseRepository<EmployeeTask> InEmployeeTasks { get; }
    }
}