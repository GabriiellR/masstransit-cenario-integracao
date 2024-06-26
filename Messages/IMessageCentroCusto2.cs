namespace Messages
{
    public interface IMessageCentroCusto
    {
        string Estrutura { get; set; }
        string Nome { get; set; }
        int BennerId { get; set; }
        bool Ativo { get; set; }
    }
}