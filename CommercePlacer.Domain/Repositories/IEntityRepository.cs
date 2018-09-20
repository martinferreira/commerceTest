using CommercePlacer.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercePlacer.Domain.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : EntityModel
    {
        TEntity GetById(int id);
        TEntity Insert(TEntity toInsert);
        TEntity Update(TEntity toUpdate);
        void DeleteById(int id);
        List<TEntity> getAll();
        int GetCount();
    }
}
