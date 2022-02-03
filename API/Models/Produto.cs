namespace API
{
    public class Produto : Entidade
    {
        public Produto(string nome, string descricao, decimal custo, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Custo = custo;
            Preco = preco;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Custo { get; private set; }
        public decimal Preco { get; private set; }
    }
}
