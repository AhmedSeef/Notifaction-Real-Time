using System;
using System.Collections.Generic;
using System.Text;

namespace Notifaction.DAL.contract.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
