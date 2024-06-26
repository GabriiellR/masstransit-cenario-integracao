using Intranet.Application.Interfaces;
using Intranet.Models;
using Intranet.Repository.Interface;

namespace Intranet.Application
{
    public class ApplicationServiceCentroCusto : IApplicationServiceCentroCusto
    {
        readonly IRepositoryCentroCusto _repositoryCentroCusto;

        public ApplicationServiceCentroCusto(IRepositoryCentroCusto repositoryCentroCusto)
        {
            _repositoryCentroCusto = repositoryCentroCusto;
        }

        public CentroCusto Delete(string estrutura)
        {
            return _repositoryCentroCusto.Delete(estrutura);
        }

        public List<CentroCusto> GetAll()
        {
            return _repositoryCentroCusto.GetAll();
        }

        public CentroCusto Post(CentroCusto centroCusto)
        {
            return _repositoryCentroCusto.Post(centroCusto);
        }

        public CentroCusto Update(CentroCusto centroCusto)
        {
            return _repositoryCentroCusto.Update(centroCusto);
        }
    }
}
