using Facens.Business.Interfaces;
using Facens.Business.Models;
using Facens.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Facens.Data.Repositories
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext appDbContext) : base(appDbContext) { }

        public async Task<Endereco> ObterEnderecoPorCidadao(Guid id)
        {
            return await Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(e => e.CidadaoId == id);
        }
    }
}
