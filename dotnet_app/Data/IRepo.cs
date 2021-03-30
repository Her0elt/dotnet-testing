using System.Collections.Generic;

namespace dotnet_app.Data
{
    public interface IRepo<T>
    {
        bool save();
        IEnumerable<T> getAll();
        T getById(int id);
        void create(T obj);
        void update(T obj);
        void delete(T obj);
    }
}