using AutoMapper;
using Facens.Api.Controllers;
using Facens.Api.ViewModels;
using Facens.Business.Enums;
using Facens.Business.Interfaces;
using Facens.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Facens.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/solicitacoes")]
    public class SolicitacaoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ISolicitacaoService _solicitacaoService;
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public SolicitacaoController(INotificator notificator, IMapper mapper, ISolicitacaoService solicitacaoService, ISolicitacaoRepository solicitacaoRepository, IUsuario usuario) : base(notificator, usuario)
        {
            _mapper = mapper;
            _solicitacaoService = solicitacaoService;
            _solicitacaoRepository = solicitacaoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<SolicitacaoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<SolicitacaoViewModel>>(await _solicitacaoRepository.ObterSolicitacoesCidadaos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SolicitacaoViewModel>> ObterPorId(Guid id)
        {
            var solicitacaoViewModel = await ObterSolicitacao(id);

            if (solicitacaoViewModel == null) return NotFound();

            return solicitacaoViewModel;
        }

        [HttpPost]
        public async Task<ActionResult<SolicitacaoViewModel>> Adicionar(SolicitacaoViewModel solicitacaoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            //var imagemNome = Guid.NewGuid() + "_" + solicitacaoViewModel.Imagem;

            //if (!UploadArquivo(solicitacaoViewModel.ImagemUpload, imagemNome))
            //{
            //    return CustomResponse(solicitacaoViewModel);
            //}

            //solicitacaoViewModel.Imagem = imagemNome;

            await _solicitacaoService.Adicionar(_mapper.Map<Solicitacao>(solicitacaoViewModel));

            return CustomResponse(solicitacaoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, Situacao situacao)
        {
            var solicitacaoAtualizacao = await ObterSolicitacao(id);

            if (solicitacaoAtualizacao == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            solicitacaoAtualizacao.Situacao = situacao;

            await _solicitacaoService.Atualizar(_mapper.Map<Solicitacao>(solicitacaoAtualizacao));

            return Ok(solicitacaoAtualizacao);
        }

        private async Task<SolicitacaoViewModel> ObterSolicitacao(Guid id)
        {
            return _mapper.Map<SolicitacaoViewModel>(await _solicitacaoRepository.ObterSolicitacaoCidadado(id));
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotifyError("Forneça uma imagem para esta solicitacao!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotifyError("Já existe uma imagem com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }
    }
}
