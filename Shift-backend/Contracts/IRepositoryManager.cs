using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryManager
    {
        INotificationRepository Notification { get; }
        IShiftRepository Shift { get; }
        void Save();
    }
}
