namespace VideoNotes.DataAccess
{
    using System.Linq;
    using VideoNotes.Core.Entities;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> Table { get; }

        T GetById(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);    
    }
}
