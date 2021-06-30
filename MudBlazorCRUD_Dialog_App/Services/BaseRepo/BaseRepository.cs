using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services.BaseRepo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> entities;

        public BaseRepository(DbContext context)
        {
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public void Create(T entity)
        {
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }

        public void Delete(int id)
        {
            T entity = entities.Find(id);
            if (entity != null)
                entities.Remove(entity);
        }

        public void DeleteAll(List<T> Entities)
        {
            if(entities!=null)
                foreach(var entity in Entities)
                {
                    entities.Remove(entity);
                }
        }
    }
}
