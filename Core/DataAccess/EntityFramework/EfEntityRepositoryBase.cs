using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext _context;

        public EfEntityRepositoryBase(TContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {

                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
            
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            
                return _context.Set<TEntity>().SingleOrDefault(filter);
            
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
              //eğer filtre göndermemişse verş kaynağından tüm datayı getir göndermişsse ona göre veriyi listele
                //veri tabanındaki bütün tabloyu listeye çevir ve bana ver 


                return filter == null
                    ? _context.Set<TEntity>().ToList()
                    : _context.Set<TEntity>().Where(filter).ToList();



            
        }

        public void Update(TEntity entity)
        {
           
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
            
        }
    }
}
