using Intranet.Models;

namespace Intranet.Application.Interfaces
{
    public interface IApplicationServiceCentroCusto
    {
        List<CentroCusto> GetAll();
        CentroCusto Delete(string estrutura);
        CentroCusto Post(CentroCusto centroCusto);
        CentroCusto Update(CentroCusto centroCusto);
    }
}
