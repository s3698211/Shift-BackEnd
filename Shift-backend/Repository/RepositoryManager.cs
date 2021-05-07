using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IShiftRepository _shiftRepository;
        private INotificationRepository _notificationRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public INotificationRepository Notification 
        { 
            get
            {
                if (_notificationRepository == null)
                    _notificationRepository = new NotificationRepository(_repositoryContext);
                return _notificationRepository;
            }  
        }
        public IShiftRepository Shift 
        { 
            get
            {
                if(_shiftRepository == null)               
                    _shiftRepository = new ShiftRepository(_repositoryContext);
                return _shiftRepository;                
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
