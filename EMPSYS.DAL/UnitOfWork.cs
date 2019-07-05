using EMPSYS.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using AppContext = EMPSYS.DAL.Context.AppContext;

namespace EMPSYS.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _db;
        private BaseRepository<Employee> _Employee;
        private BaseRepository<Role> _Role;
        private BaseRepository<Task> _Task;
        private BaseRepository<EmployeeTask> _EmployeeTask;
        public UnitOfWork(AppContext context)
        {
            _db = context;
        }

        public BaseRepository<Employee> InEmployees
        {
            get{
                return (_Employee == null) ? _Employee : new BaseRepository<Employee>(_db);
            }
        }

        public BaseRepository<Task> InTasks
        {
            get
            {
                return (_Task == null) ? _Task : new BaseRepository<Task>(_db);
            }
        }

        public BaseRepository<Role> InRoles
        {
            get{
                return (_Role == null) ? _Role : new BaseRepository<Role>(_db);
            }
        }

        public BaseRepository<EmployeeTask> InEmployeeTasks
        {
            get
            {
                return (_EmployeeTask == null) ? _EmployeeTask : new BaseRepository<EmployeeTask>(_db);
            }
        }

        public bool SaveChanges()
        {
            try
            {
                return _db.SaveChanges() > 1;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
