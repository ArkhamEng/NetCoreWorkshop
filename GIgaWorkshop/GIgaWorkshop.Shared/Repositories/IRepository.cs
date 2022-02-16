namespace GigaWorkshop.Shared.Repositories
{
    public interface IRepository<TEntity,TId> where TEntity : class
    {
        TEntity Get(TId id);

        void Delete(TId id);

        void Update(TEntity entity);

        void Add(TEntity entity);
    }
}
