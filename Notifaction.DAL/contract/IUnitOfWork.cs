using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.DAL.contract
{
    interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
