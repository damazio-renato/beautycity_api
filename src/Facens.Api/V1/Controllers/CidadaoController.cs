using AutoMapper;
using Facens.Api.Controllers;
using Facens.Api.ViewModels;
using Facens.Business.Interfaces;
using Facens.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Facens.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/cidadaos")]
    public class CidadaoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICidadaoService _cidadaoService;
        private readonly ICidadaoRepository _cidadaoRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public CidadaoController(INotificator notificator, IMapper mapper, ICidadaoService cidadaoService, ICidadaoRepository cidadaoRepository, IEnderecoRepository enderecoRepository, IUsuario usuario) : base(notificator, usuario)
        {
            _mapper = mapper;
            _cidadaoRepository = cidadaoRepository;
            _cidadaoService = cidadaoService;
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CidadaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CidadaoViewModel>>(await _cidadaoRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CidadaoViewModel>> ObterPorId(Guid id)
        {
            var fornecedor = await ObterCidadaoSolicitacoesEndereco(id);

            if (fornecedor == null) return NotFound();

            return fornecedor;
        }

        [HttpPost]
        public async Task<ActionResult<CidadaoViewModel>> Adicionar(CidadaoViewModel cidadaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadaoService.Adicionar(_mapper.Map<Cidadao>(cidadaoViewModel));

            return CustomResponse(cidadaoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CidadaoViewModel>> Atualizar(Guid id, CidadaoViewModel cidadaoViewModel)
        {
            if (id != cidadaoViewModel.Id)
            {
                NotifyError("O id informado não é o mesmo que passado no formulário");
                return CustomResponse(cidadaoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadaoService.Atualizar(_mapper.Map<Cidadao>(cidadaoViewModel));

            return CustomResponse(cidadaoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CidadaoViewModel>> Excluir(Guid id)
        {
            var cidadaoViewModel = await ObterFornecedorEndereco(id);

            if (cidadaoViewModel == null) return NotFound();

            await _cidadaoService.Remover(id);

            return CustomResponse(cidadaoViewModel);
        }

        [HttpGet("endereco/{id:guid}")]
        public async Task<EnderecoViewModel> ObterEnderecoPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
        }

        [HttpPut("endereco/{id:guid}")]
        public async Task<IActionResult> AtualizarEndereco(Guid id, EnderecoViewModel enderecoViewModel)
        {
            if (id != enderecoViewModel.Id)
            {
                NotifyError("O id informado não é o mesmo passado no formulário");
                return CustomResponse(enderecoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _cidadaoService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoViewModel));

            return CustomResponse(enderecoViewModel);
        }

        private async Task<CidadaoViewModel> ObterCidadaoSolicitacoesEndereco(Guid id)
        {
            return _mapper.Map<CidadaoViewModel>(await _cidadaoRepository.ObterCidadaoSolicitacoesEndereco(id));
        }

        private async Task<CidadaoViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<CidadaoViewModel>(await _cidadaoRepository.ObterCidadaoEndereco(id));
        }
    }
}
