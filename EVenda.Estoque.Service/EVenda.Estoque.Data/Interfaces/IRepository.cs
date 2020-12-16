using EVenda.Estoque.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evenda.Estoque.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        Task<int> SaveChanges();
    }
}
