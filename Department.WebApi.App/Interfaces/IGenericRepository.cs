

using System.Collections.Generic;

namespace Department.WebApi.App.Interfaces
{
    public interface IGenericRepository<T> where T : class , new()
    {
        public List<T> GetAll();
        

        public T GetById(int id);
        public void DeleteById(int id);
        public void UpdateById(T entity);
        public T Create(T entity);

    }
}
