﻿using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Consts;
using RepositoryPatternWithUOW.Core.Repositories;
using RepositoryPatternWithUOW.EF.AppDbContext;
using System.Linq.Expressions;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class


    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);

        }

        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)//criteria is lambda Expression
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.SingleOrDefault(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.Where(criteria).ToList();
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int take, int skip)
        {

            return _context.Set<T>().Where(criteria).Take(take).Skip(skip).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query.Take(take.Value);
            if (skip.HasValue)
                query.Take(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                {
                    query = query.OrderByDescending(orderBy);
                }
            }
            return query.ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public int Count()
        {
            return _context.Set<T>().Count();

        }

        public int Count(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().Count(criteria);

        }
    }
}
