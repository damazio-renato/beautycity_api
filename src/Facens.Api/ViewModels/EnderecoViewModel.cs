using Facens.Business.Models;
using System.ComponentModel.DataAnnotations;

namespace Facens.Api.ViewModels
{
    public class EnderecoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo CEP deve ter {1} caracteres")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo estado é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo logradouro é obrigatório")]
        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Complemento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Inclusao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Alteracao { get; set; }

        public Guid CidadaoId { get; set; }
    }
}
