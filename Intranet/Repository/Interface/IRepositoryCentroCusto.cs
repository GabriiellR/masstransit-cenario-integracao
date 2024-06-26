using Intranet.Models;

namespace Intranet.Repository.Interface
{
    public interface IRepositoryCentroCusto
    {
        CentroCusto Delete(string estrutura);
        List<CentroCusto> GetAll();
    }
}
