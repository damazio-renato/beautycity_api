using Facens.Business.Interfaces;
using Facens.Business.Models;
using Facens.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Facens.Data.Repositories
{
    public class CidadaoRepository : Repository<Cidadao>, ICidadaoRepository
    {
        public CidadaoRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Cidadao> ObterCidadaoEndereco(Guid id)
        {
            return await Db.Cidadaos.AsNoTracking().Include(e => e.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cidadao> ObterCidadaoSolicitacoesEndereco(Guid id)
        {
            return await Db.Cidadaos.AsNoTracking().Include(s => s.Solicitacoes).Include(e => e.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
