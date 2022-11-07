namespace Confitec.API.Domain.Contracts.Base
{
    public interface IGenericHandler<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById<IEntity>(int id);
        TEntity Delete(TEntity obj);
        Task<TEntity> Create(TEntity obj);
        TEntity Update(TEntity obj);
    }
}
