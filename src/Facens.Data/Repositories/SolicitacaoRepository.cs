using Facens.Business.Interfaces;
using Facens.Business.Models;
using Facens.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Facens.Data.Repositories
{
    public class SolicitacaoRepository : Repository<Solicitacao>, ISolicitacaoRepository
    {
        public SolicitacaoRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Solicitacao> ObterSolicitacaoCidadado(Guid id)
        {
            return await Db.Solicitacoes.AsNoTracking().Include(c => c.Cidadao).Include(c => c.Categoria).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Solicitacao>> ObterSolicitacaoPorCidadado(Guid id)
        {
            return await Buscar(s => s.CidadaoId == id);
        }

        public async Task<IEnumerable<Solicitacao>> ObterSolicitacoesCidadaos()
        {
            return await Db.Solicitacoes.AsNoTracking().Include(c => c.Cidadao).Include(c => c.Categoria).OrderBy(s => s.Situacao).ToListAsync();
        }
    }
}
