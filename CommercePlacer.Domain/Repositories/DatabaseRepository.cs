using CommercePlacer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercePlacer.Domain.Repositories
{
    public class DatabaseRepository<TEntity> : IEntityRepository<TEntity> where TEntity : EntityModel
    {
        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> getAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity toInsert)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity toUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
