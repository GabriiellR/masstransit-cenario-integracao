using Intranet.Models;
using Intranet.Repository.Interface;

namespace Intranet.Repository
{
    public class RepositoryCentroCusto : IRepositoryCentroCusto
    {

        private readonly List<CentroCusto> _centroCusto = new List<CentroCusto>();

        public RepositoryCentroCusto()
        {
            _centroCusto.Add(new CentroCusto { Estrutura = "02.01", Nome = "Matriz", Ativo = true, BennerId = 0 });
            _centroCusto.Add(new CentroCusto { Estrutura = "02.02", Nome = "Estoque", Ativo = false, BennerId = 0 });
        }

        public CentroCusto Delete(string estrutura)
        {
            var centroCustoParaDeletar = GetByEstrutura(estrutura);
            _centroCusto.Remove(centroCustoParaDeletar);
            return centroCustoParaDeletar;
        }

        public List<CentroCusto> GetAll()
        {
            return _centroCusto;
        }

        CentroCusto GetByEstrutura(string estrutura)
        {
            return _centroCusto.FirstOrDefault(prop => prop.Estrutura.Equals(estrutura));
        }
    }
}
