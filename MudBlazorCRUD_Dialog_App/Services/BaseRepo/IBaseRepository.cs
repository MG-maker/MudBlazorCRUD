using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MudBlazorCRUD_Dialog_App.Services.BaseRepo
{
   public interface IBaseRepository <T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
       void Create(T entity);
       void Update(T entity);
       void Delete(int id);
       void DeleteAll(List<T> Entities);
    }
}
