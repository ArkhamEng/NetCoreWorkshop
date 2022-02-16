using GigaWorkshop.Shared.Repositories;

namespace GigaWorkshop.DataAccess.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        protected readonly WorkshopDbContext db;

        public Repository(WorkshopDbContext db)
        {
            this.db = db;
        }
        public virtual void Add(TEntity entity)
        {
            this.db.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TId id)
        {
            var entity = this.db.Set<TEntity>().Find(id);

            if(entity != null)
                this.db.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity Get(TId id)
        {
            var entity = this.db.Set<TEntity>().Find(id);
            return entity != null ? entity : null;
        }

        public virtual void Update(TEntity entity)
        {
            this.db.Set<TEntity>().Update(entity);
        }
    }
}
