using Facens.Business.Models;

namespace Facens.Business.Interfaces
{
    public interface ISolicitacaoRepository : IRepository<Solicitacao>
    {
        Task<IEnumerable<Solicitacao>> ObterSolicitacaoPorCidadado(Guid id);
        Task<IEnumerable<Solicitacao>> ObterSolicitacoesCidadaos();
        Task<Solicitacao> ObterSolicitacaoCidadado(Guid id);
    }
}
