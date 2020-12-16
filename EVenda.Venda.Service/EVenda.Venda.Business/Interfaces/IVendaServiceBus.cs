namespace EVenda.Venda.Business.Interfaces
{
    public interface IVendaServiceBus
    {
        void ListenProdutoCriado();
        void ListenProdutoAlterado();
    }
}
