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
