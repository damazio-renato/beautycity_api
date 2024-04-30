using Facens.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace Facens.Api.ViewModels
{
    public class SolicitacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo latitude é obrigatório")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "O campo longitude é obrigatório")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public Situacao Situacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Inclusao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Alteracao { get; set; }

        public Guid CategoriaId { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCategoria { get; set; }

        public Guid CidadaoId { get; set; }

        [ScaffoldColumn(false)]
        public string NomeCidadao { get; set; }
    }
}
