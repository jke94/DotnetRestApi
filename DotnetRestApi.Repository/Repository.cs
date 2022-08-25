namespace DotnetRestApi.Repository
{
    #region

    using DotnetRestApi.Abstractions;
    using DotnetRestApi.Abstractions.Repository;
    using System.Collections.Generic;

    #endregion

    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private IDbContext<T> _ctx;

        public Repository(IDbContext<T> ctx)
        {
            _ctx = ctx;
        }

        public void Delete(int id)
        {
            _ctx.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _ctx.GetAll();
        }

        public T GetById(int id)
        {
            return _ctx.GetById(id);
        }

        public T Save(T entity)
        {
            return _ctx.Save(entity);
        }

        public T Update(T entity)
        {
            return _ctx.Update(entity);
        }
    }
}
