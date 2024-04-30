using Facens.Business.Models;

namespace Facens.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorCidadao(Guid id);
    }
}
