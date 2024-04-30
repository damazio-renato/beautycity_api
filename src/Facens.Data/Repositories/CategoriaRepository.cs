using Facens.Business.Interfaces;
using Facens.Business.Models;
using Facens.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Facens.Data.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<IEnumerable<Solicitacao>> ObterSolicitacoesPorCategoria(Guid id)
        {
            return await Db.Solicitacoes.AsNoTracking().Include(s => s.Categoria).Where(c => c.CategoriaId == id).ToListAsync();
        }
    }
}
