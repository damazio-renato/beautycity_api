using Facens.Business.Models;

namespace Facens.Business.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Solicitacao>> ObterSolicitacoesPorCategoria(Guid id);
    }
}
