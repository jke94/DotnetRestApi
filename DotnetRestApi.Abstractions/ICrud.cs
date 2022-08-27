namespace DotnetRestApi.Abstractions
{
    using System.Collections.Generic;

    public interface ICrud<T>
    {
        T Save(T entity);
        
        IList<T> GetAll();
        
        T? GetById(int id);

        bool Remove(T entity);

        T Update(T entity);
    }
}
