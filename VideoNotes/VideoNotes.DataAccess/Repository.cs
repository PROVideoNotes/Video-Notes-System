namespace VideoNotes.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core;
    using System.Data.Entity.Validation;
    using System.Linq;
    using VideoNotes.Core;

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbContext context;
        private IDbSet<T> entities;

        public Repository(IDbContext context)
        {
            this.context = context;
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (this.entities == null)
                {
                    this.entities = this.context.Set<T>();
                }

                return this.entities;
            }
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Add(entity);
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbException)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbException.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += string.Format(
                            "Property: {0} Error: {1}",
                        validationError.PropertyName,
                        validationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(msg, dbException);
                throw fail;
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format(
                            "Property: {0} Error: {1}",
                        validationError.PropertyName,
                        validationError.ErrorMessage);
                    }
                }

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                this.Entities.Remove(entity);
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbException)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbException.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        msg += Environment.NewLine + string.Format(
                            "Property: {0} Error: {1}",
                        validationError.PropertyName,
                        validationError.ErrorMessage);
                    }
                }

                var fail = new Exception(msg, dbException);
                throw fail;
            }
        }
    }
}
