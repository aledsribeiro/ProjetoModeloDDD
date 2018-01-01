using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoModeloDDD.Infra.Data.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public IEnumerable<Produto> BuscarPorNome(string Nome)
        {
            return Db.Produtos.Where(p => p.NomeProduto == Nome);
        }
    }
}
