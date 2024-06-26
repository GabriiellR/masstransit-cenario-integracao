namespace BennerApi.Models
{
    public class CentroCusto
    {
        public string Estrutura { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public int BennerId { get; set; }
    }
}
