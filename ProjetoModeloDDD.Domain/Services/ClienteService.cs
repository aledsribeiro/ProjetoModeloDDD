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
    public class ClienteService: ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRespositorio _clienteRepositorio;

        public ClienteService(IClienteRespositorio clienteRepositorio)
            :base(clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public IEnumerable<Cliente> ObterClienteEspecial(IEnumerable<Cliente> clientes)
        {
            return clientes.Where(c => c.ClienteEspecial(c));
        }
    }
}
 