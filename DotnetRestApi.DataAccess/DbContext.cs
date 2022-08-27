namespace DotnetRestApi.DataAccess
{ 
    using System.Linq;
    using DotnetRestApi.Abstractions;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Xml.Linq;

    public class DbContext<T> : IDbContext<T> where T : class, IEntity
    {
        private DbSet<T> _items;

        private ApiDbContext _ctx;

        public DbContext(ApiDbContext ctx)
        {
            _ctx = ctx;
            _items = ctx.Set<T>();
        }

        public bool Remove(T entity)
        {
            var item = _items.Remove(entity);
            _ctx.SaveChanges();

            return item is not null;
        }

        public IList<T> GetAll()
        {
            return _items.ToList();
        }

        public T? GetById(int id)
        {
            return _items?.Where(item => item.Id.Equals(id)).FirstOrDefault(); 
        }

        public T Save(T entity)
        {
            _items.Add(entity);
            _ctx.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            _items.Update(entity);
            _ctx.SaveChanges();

            return entity;
        }
    }
}
