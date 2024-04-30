using Facens.Business.Enums;

namespace Facens.Business.Models
{
    public class Solicitacao : EntidadeBase
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public Situacao Situacao { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public Guid CidadaoId { get; set; }
        public Cidadao Cidadao { get; set; }
    }
}
