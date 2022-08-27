namespace DotnetRestApi.Application
{
    #region using

    using DotnetRestApi.Abstractions;
    using DotnetRestApi.Abstractions.Application;
    using DotnetRestApi.Abstractions.Repository;
    using System.Collections.Generic;

    #endregion

    public class Application<T> : IApplication<T> where T : IEntity
    {
        private IRepository<T> _repository;

        public Application(IRepository<T> repository)
        {
            _repository = repository;
        }

        public bool Remove(T entity)
        {
            return _repository.Remove(entity);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
