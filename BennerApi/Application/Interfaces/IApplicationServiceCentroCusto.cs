using BennerApi.Models;

namespace BennerApi.Application.Interfaces
{
    public interface IApplicationServiceCentroCusto
    {
        Task<CentroCusto> Delete(string estrutura);
        List<CentroCusto> GetAll();
        Task<CentroCusto> Post(CentroCusto centroCusto);
        Task<CentroCusto> Update(CentroCusto centroCusto);
    }
}
