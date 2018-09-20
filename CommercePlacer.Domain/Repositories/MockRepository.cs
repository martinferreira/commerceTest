using CommercePlacer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercePlacer.Domain.Repositories
{
    public class MockRepository<TEntity> : IEntityRepository<TEntity> where TEntity : EntityModel
    {
        private List<TEntity> repo;
        public MockRepository()
        {
            repo = new List<TEntity>();
        }

        public void DeleteById(int id)
        {
            repo.Remove(GetById(id));
        }

        public List<TEntity> getAll()
        {
            return repo;
        }

        public TEntity GetById(int id)
        {
            return repo.FirstOrDefault(m => m.Id == id);
        }

        public int GetCount()
        {
            return repo.Count;
        }

        public TEntity Insert(TEntity toInsert)
        {
            if (toInsert.Id == 0)
            {
                toInsert.Id = repo.Count+1;
            }
            repo.Add(toInsert);
            return toInsert;
        }

        public TEntity Update(TEntity toUpdate)
        {
            DeleteById(toUpdate.Id);
            return Insert(toUpdate);
        }
    }
}
