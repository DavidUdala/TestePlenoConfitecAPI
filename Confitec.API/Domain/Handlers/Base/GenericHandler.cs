using Confitec.API.Context;
using Confitec.API.Domain.Contracts.Base;
using Confitec.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Confitec.API.Domain.Handlers.Base
{
    public abstract class GenericHandler<TEntity> : IGenericHandler<TEntity> where TEntity : class, IEntity
    {
        private readonly AppDbContext _ctx;
        public GenericHandler(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TEntity> GetById<IEntity>(int id)
        {
            var result = await _ctx.Set<TEntity>().SingleAsync(t => t.Id == id);

            return result;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var result = await _ctx.Set<TEntity>().ToListAsync();

            return result;
        }
        public TEntity Delete(TEntity obj)
        {
            var result = this._ctx.Set<TEntity>().Remove(obj);
            this._ctx.SaveChanges();
            return result.Entity;
        }

        public async Task<TEntity> Create(TEntity obj)
        {
            var result = await this._ctx.Set<TEntity>().AddAsync(obj);
            this._ctx.SaveChanges();

            return result.Entity;
        }

        public TEntity Update(TEntity obj)
        {
            var result = this._ctx.Set<TEntity>().Update(obj);
            this._ctx.SaveChanges();

            return result.Entity;
        }

    }
}
