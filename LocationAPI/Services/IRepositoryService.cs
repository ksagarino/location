using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationAPI.Services
{
    public interface IRepositoryService<TEntity> where TEntity : class
    {
        
        IEnumerable<TEntity> Get();

        TEntity GetByID(object id);

        void Insert(TEntity entity);

        void Update(TEntity entityToUpdate);
    }
}
