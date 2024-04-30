using AutoMapper;
using Facens.Api.Controllers;
using Facens.Api.Extensions;
using Facens.Api.ViewModels;
using Facens.Business.Interfaces;
using Facens.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Facens.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/categorias")]
    public class CategoriaController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(INotificator notificator, IMapper mapper, ICategoriaService categoriaService, ICategoriaRepository categoriaRepository, IUsuario usuario) : base(notificator, usuario)
        {
            _mapper = mapper;
            _categoriaService = categoriaService;
            _categoriaRepository = categoriaRepository;
        }

        [ClaimsAuthorize("Categoria", "R")]
        [HttpGet]
        public async Task<IEnumerable<CategoriaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>(await _categoriaRepository.ObterTodos());
        }

        [ClaimsAuthorize("Categoria", "R")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> ObterPorId(Guid id)
        {
            var categoriaViewModel = await ObterCategoria(id);

            if (categoriaViewModel == null) return NotFound();

            return categoriaViewModel;
        }

        [ClaimsAuthorize("Categoria", "C")]
        [HttpPost]
        public async Task<ActionResult<CategoriaViewModel>> Adicionar(CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaService.Adicionar(_mapper.Map<Categoria>(categoriaViewModel));

            return CustomResponse(categoriaViewModel);
        }

        [ClaimsAuthorize("Categoria", "U")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Atualizar(Guid id, CategoriaViewModel categoriaViewModel)
        {
            if (id != categoriaViewModel.Id)
            {
                NotifyError("O id informado não é o mesmo que passado no formulário");
                return CustomResponse(categoriaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoriaService.Atualizar(_mapper.Map<Categoria>(categoriaViewModel));

            return CustomResponse(categoriaViewModel);
        }

        [ClaimsAuthorize("Categoria", "D")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoriaViewModel>> Excluir(Guid id)
        {
            var categoriaViewModel = await ObterCategoria(id);

            if (categoriaViewModel == null) return NotFound();

            await _categoriaService.Remover(id);

            return CustomResponse(categoriaViewModel);
        }

        private async Task<CategoriaViewModel> ObterCategoria(Guid id)
        {
            return _mapper.Map<CategoriaViewModel>(await _categoriaRepository.ObterPorId(id));
        }
    }
}
