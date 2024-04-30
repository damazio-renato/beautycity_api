namespace Facens.Business.Models
{
    public class Categoria : EntidadeBase
    {
        public string Descricao { get; set; }
        public DateTime Inclusao { get; set; }
        public DateTime Alteracao { get; set; }
        public Solicitacao Solicitacao { get; set; }
    }
}
