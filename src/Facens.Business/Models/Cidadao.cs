namespace Facens.Business.Models
{
    public class Cidadao : EntidadeBase
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public bool Ativo { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Solicitacao> Solicitacoes { get; set; }
    }
}
