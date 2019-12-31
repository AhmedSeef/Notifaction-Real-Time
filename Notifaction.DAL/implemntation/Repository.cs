using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Notifaction.DAL.contract;
using Notifaction.DB;
using Notifaction.Models.Bas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Notifaction.DAL.implemntation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly DataContext _Context;

        public Repository(DataContext Context)
        {
            _Context = Context;
        }

        public TEntity Get(int id)
        {
            var data = _Context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
            return data;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _Context.Set<TEntity>().AsNoTracking();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public string AddOrUpdate(TEntity entity)
        {
            string status = "";
            try
            {
                if (entity.Id > 0)
                {
                    _Context.Entry(entity).State = EntityState.Modified;
                    return status = "Updated";
                }
                else
                {
                    _Context.Set<TEntity>().Add(entity);
                    return status = "Added";
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex.InnerException;
            }
            catch (DbUpdateException ex)
            {
                throw ex.InnerException;
            }

            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().AddRangeAsync(entities);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex.InnerException;
            }
            catch (DbUpdateException ex)
            {
                throw ex.InnerException;
            }

            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void Remove(TEntity entity)
        {
            try
            {
                _Context.Set<TEntity>().Remove(entity);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex.InnerException;
            }
            catch (DbUpdateException ex)
            {
                throw ex.InnerException;
            }

            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _Context.Set<TEntity>().RemoveRange(entities);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex.InnerException;
            }
            catch (DbUpdateException ex)
            {
                throw ex.InnerException;
            }

            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
