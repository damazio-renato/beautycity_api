using Facens.Business.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Facens.Api.ViewModels
{
    public class CidadaoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo CPF deve ter {1} caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo email está em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo celular é obrigatório")]
        public string Celular { get; set; }

        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Inclusao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Alteracao { get; set; }

        public EnderecoViewModel Endereco { get; set; }

        public IEnumerable<SolicitacaoViewModel> Solicitacoes { get; set; }
    }
}
