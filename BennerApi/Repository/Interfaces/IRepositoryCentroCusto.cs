using BennerApi.Models;

namespace BennerApi.Repository.Interfaces
{
    public interface IRepositoryCentroCusto
    {
        CentroCusto Delete(string estrutura);
        List<CentroCusto> GetAll();
        CentroCusto Post(CentroCusto centroCusto);
        CentroCusto Update(CentroCusto centroCusto);
    }
}
