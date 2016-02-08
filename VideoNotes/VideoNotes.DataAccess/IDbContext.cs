namespace VideoNotes.DataAccess
{
    using System.Data.Entity;

    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
    }
}
