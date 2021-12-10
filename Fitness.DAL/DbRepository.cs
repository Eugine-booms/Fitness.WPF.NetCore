using Fitness.DAL.Context;
using Fitness.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fitness.DAL
{
    public class DbRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly FitnessDb _db;
        private readonly DbSet<T> _set;
        public bool AutosaveChange { get; set; }

        public DbRepository(FitnessDb db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _set = _db.Set<T>();
        }

        public virtual IQueryable<T> Items => _set;

        

        public T Add(T item)
        {
           if(item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Added;
            if (AutosaveChange)
            {
                _db.SaveChanges();
            }
            return item;
        }



        public T Get(int id) => Items.SingleOrDefault(item => item.Id == id);



        public T Remove(int id) => _db.Remove(_set.Local.FirstOrDefault(i => i.Id == id)).Entity;
        //{
            
        //    var item = _db.Remove(_set.Local.FirstOrDefault(i => i.Id == id));
        //    return item.Entity;
        //}

       

        public T Update(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            _db.Entry(item).State = EntityState.Modified;
            if (AutosaveChange)
            {
                _db.SaveChanges();
            }
            return item;
        }

        #region Асинхронные операции
        public Task<T> AddAsync(T items, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
        public Task<T> GetAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
        public Task<T> RemoveAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
        public Task<T> UpdateAsync(T items, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        } 
        #endregion

    }
}
