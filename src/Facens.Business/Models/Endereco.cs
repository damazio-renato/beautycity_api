namespace Facens.Business.Models
{
    public class Endereco : EntidadeBase
    {
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }
        public Guid CidadaoId { get; set; }
        public Cidadao Cidadao { get; set; }
    }
}
