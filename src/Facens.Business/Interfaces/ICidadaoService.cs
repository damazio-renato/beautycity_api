using Facens.Business.Models;

namespace Facens.Business.Interfaces
{
    public interface ICidadaoService : IDisposable
    {
        Task Adicionar(Cidadao cidadao);
        Task Atualizar(Cidadao cidadao);
        Task Remover(Guid id);
        Task AtualizarEndereco(Endereco endereco);
    }
}
