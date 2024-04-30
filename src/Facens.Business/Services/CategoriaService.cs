using Facens.Business.Interfaces;
using Facens.Business.Models;
using Facens.Business.Validations;

namespace Facens.Business.Services
{
    public class CategoriaService : ServiceBase, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(INotificator notificator, ICategoriaRepository categoriaRepository) : base(notificator)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task Adicionar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            await _categoriaRepository.Adicionar(categoria);
        }

        public async Task Atualizar(Categoria categoria)
        {
            if (!ExecutarValidacao(new CategoriaValidation(), categoria)) return;

            await _categoriaRepository.Atualizar(categoria);
        }

        public async Task Remover(Guid id)
        {
            if (_categoriaRepository.ObterSolicitacoesPorCategoria(id).Result.Any())
            {
                Notificar("O categoria possui solicitacoes vinculadas, não é possível excluir!");
                return;
            }

            await _categoriaRepository.Remover(id);
        }

        public void Dispose()
        {
            _categoriaRepository?.Dispose();
        }
    }
}
