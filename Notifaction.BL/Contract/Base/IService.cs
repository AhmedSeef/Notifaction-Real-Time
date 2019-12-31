using Notifaction.Models.Bas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifaction.BL.Contract.Base
{
    public interface IService<TEntity> where TEntity : BaseModel
    {
        TEntity Get(int id);
        IQueryable<TEntity> GetAll();

        string AddOrUpdate(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(int id);

    }
}
