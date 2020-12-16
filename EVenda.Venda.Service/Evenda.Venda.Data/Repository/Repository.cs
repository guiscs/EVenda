using Evenda.Venda.Data.Interfaces;
using EVenda.Venda.Data.Context;
using EVenda.Venda.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVenda.Venda.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly VendaContext _ctxDB;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(VendaContext db)
        {
            _ctxDB = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _ctxDB.SaveChangesAsync();
        }

        public void Dispose()
        {
            _ctxDB?.Dispose();
        }
    }
}
