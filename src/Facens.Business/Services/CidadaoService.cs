using Facens.Business.Interfaces;
using Facens.Business.Models;
using Facens.Business.Validations;

namespace Facens.Business.Services
{
    public class CidadaoService : ServiceBase, ICidadaoService
    {
        private readonly ICidadaoRepository _cidadaoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public CidadaoService(INotificator notificator, ICidadaoRepository cidadaoRepository, IEnderecoRepository enderecoRepository) : base(notificator)
        {
            _cidadaoRepository = cidadaoRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Cidadao cidadao)
        {
            if (cidadao.Endereco == null)
            {
                Notificar("É obrigatório informar os dados do endereco"); return;
            }

            if (!ExecutarValidacao(new CidadaoValidation(), cidadao) 
                || !ExecutarValidacao(new EnderecoValidation(), cidadao.Endereco)) return;

            if (_cidadaoRepository.Buscar(c => c.Cpf == cidadao.Cpf).Result.Any())
            {
                Notificar("Já existe um cidadão cadastrado com o CPF informado"); return;
            }

            await _cidadaoRepository.Adicionar(cidadao);
        }

        public async Task Atualizar(Cidadao cidadao)
        {
            if (!ExecutarValidacao(new CidadaoValidation(), cidadao)) return;

            if (_cidadaoRepository.Buscar(c => c.Cpf == cidadao.Cpf && c.Id != cidadao.Id).Result.Any())
            {
                Notificar("Já existe um cidadão cadastrado com o CPF informado");
                return;
            }

            await _cidadaoRepository.Atualizar(cidadao);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            if (_cidadaoRepository.ObterCidadaoSolicitacoesEndereco(id).Result.Solicitacoes.Any())
            {
                Notificar("O cidadao possui solicitacoes vinculadas, não é possível excluir!");
                return;
            }

            var endereco = await _enderecoRepository.ObterEnderecoPorCidadao(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _cidadaoRepository.Remover(id);
        }

        public void Dispose()
        {
            _cidadaoRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
