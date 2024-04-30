using Facens.Business.Models;

namespace Facens.Business.Interfaces
{
    public interface ISolicitacaoService : IDisposable
    {
        Task Adicionar(Solicitacao solicitacao);
        Task Atualizar(Solicitacao solicitacao);
        Task Remover(Guid id);
    }
}
