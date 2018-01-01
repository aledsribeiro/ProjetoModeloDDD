using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Repositorio;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Services
{
    public class ProdutoService: ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio)
            :base(produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IEnumerable<Produto> BuscarPorNome(string Nome)
        {
            return _produtoRepositorio.BuscarPorNome(Nome);
        }
    }
}
