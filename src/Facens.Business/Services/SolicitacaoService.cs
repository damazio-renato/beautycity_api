using Facens.Business.Interfaces;
using Facens.Business.Models;
using Facens.Business.Validations;

namespace Facens.Business.Services
{
    public class SolicitacaoService : ServiceBase, ISolicitacaoService
    {
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public SolicitacaoService(ISolicitacaoRepository solicitacaoRepository, INotificator notificator) : base(notificator)
        {
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task Adicionar(Solicitacao solicitacao)
        {
            if (!ExecutarValidacao(new SolicitacaoValidation(), solicitacao)) return;

            await _solicitacaoRepository.Adicionar(solicitacao);
        }

        public async Task Atualizar(Solicitacao solicitacao)
        {
            if (!ExecutarValidacao(new SolicitacaoValidation(), solicitacao)) return;

            await _solicitacaoRepository.Atualizar(solicitacao);
        }

        public async Task Remover(Guid id)
        {
            await _solicitacaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _solicitacaoRepository?.Dispose();
        }
    }
}
