using Facens.Business.Models;

namespace Facens.Business.Interfaces
{
    public interface ICidadaoRepository : IRepository<Cidadao>
    {
        Task<Cidadao> ObterCidadaoEndereco(Guid id);
        Task<Cidadao> ObterCidadaoSolicitacoesEndereco(Guid id);
    }
}
