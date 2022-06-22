using Department.WebApi.App.Data;
using Department.WebApi.App.Interfaces;
using Department.WebApi.App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Department.WebApi.App.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void DeleteById(int id)
        {
            var del = _context.Set<T>().Find(id);

            _context.Set<T>().Remove(del);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var query = _context.Set<T>().Find(id);
            if (query == null)
            {
                return null;
            }
            return query;
        }

        public void UpdateById(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
