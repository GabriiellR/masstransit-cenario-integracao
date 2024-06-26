using Intranet.Models;

namespace Intranet.Repository.Interface
{
    public interface IRepositoryCentroCusto
    {
        CentroCusto Delete(string estrutura);
        List<CentroCusto> GetAll();
        CentroCusto Post(CentroCusto centroCusto);
        CentroCusto Update(CentroCusto centroCUsto);
    }
}
