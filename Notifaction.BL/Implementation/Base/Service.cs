using Notifaction.BL.Contract.Base;
using Notifaction.DAL.contract.Base;
using Notifaction.Models.Bas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifaction.BL.Implementation.Base
{
    public class Service<TEntity> : IService<TEntity> where TEntity : BaseModel
    {
        IUnitOfWork _unitOfWork;
        IRepository<TEntity> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public string AddOrUpdate(TEntity entity)
        {
            string status = _repository.AddOrUpdate(entity);
            _unitOfWork.Commit();
            return status;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _repository.AddRange(entities);
            _unitOfWork.Commit();
        }

        public TEntity Get(int id)
        {
            return _repository.Get(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(int id)
        {
            var entity = _repository.Get(id);
            if (entity != null)
                _repository.Remove(entity);
            _unitOfWork.Commit();
        }


    }
}
