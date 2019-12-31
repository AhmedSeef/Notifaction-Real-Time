using Microsoft.EntityFrameworkCore;
using Notifaction.DAL.contract.Base;
using Notifaction.DB;
using System;


namespace Notifaction.DAL.implemntation.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext _Context;
        public UnitOfWork(DataContext Context)
        {
            _Context = Context;
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public void Commit()
        {
            // Save changes with the default options
            try
            {
                _Context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                //This either returns a error string, or null if it can’t handle that error

                throw e.InnerException; //couldn’t handle that error, so rethrow
            }
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_Context != null)
                {
                    _Context.Dispose();
                    _Context = null;
                }
            }
        }
    }
}
