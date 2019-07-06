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
                return (_Employee == null) ? new BaseRepository<Employee>(_db):_Employee ;
            }
        }

        public BaseRepository<Task> InTasks
        {
            get
            {
                return (_Task == null) ? new BaseRepository<Task>(_db): _Task;
            }
        }

        public BaseRepository<Role> InRoles
        {
            get{
                return (_Role == null) ? new BaseRepository<Role>(_db) : _Role;
            }
        }

        public BaseRepository<EmployeeTask> InEmployeeTasks
        {
            get
            {
                return (_EmployeeTask == null) ? new BaseRepository<EmployeeTask>(_db): _EmployeeTask;
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
