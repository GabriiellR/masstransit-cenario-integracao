using BennerApi.Application.Interfaces;
using BennerApi.CrossCutting;
using BennerApi.Models;
using BennerApi.Repository.Interfaces;

namespace BennerApi.Application
{
    public class ApplicationServiceCentroCusto : IApplicationServiceCentroCusto
    {
        readonly IRepositoryCentroCusto _repositoryCentroCusto;
        readonly IApplicationServicePublisher _applicationServicePublisher;
        public ApplicationServiceCentroCusto(IRepositoryCentroCusto repositoryCentroCusto, IApplicationServicePublisher applicationServicePublisher)
        {
            _repositoryCentroCusto = repositoryCentroCusto;
            _applicationServicePublisher = applicationServicePublisher;
        }

        public async Task<CentroCusto> Delete(string estrutura)
        {
            var centroCustoDeletado = _repositoryCentroCusto.Delete(estrutura);

            var fila = Enum.GetName(typeof(FilasEnum), FilasEnum.Delete).ToString();
            _applicationServicePublisher.EnviarModificacaoCentroCusto(centroCustoDeletado, fila);


            return centroCustoDeletado;
        }

        public List<CentroCusto> GetAll()
        {
            return _repositoryCentroCusto.GetAll();
        }

        public async Task<CentroCusto> Post(CentroCusto centroCusto)
        {
            var centroCustoCriado = _repositoryCentroCusto.Post(centroCusto);

            var fila = Enum.GetName(typeof(FilasEnum), FilasEnum.Create).ToString();
            _applicationServicePublisher.EnviarModificacaoCentroCusto(centroCustoCriado, fila);

            return centroCusto;
        }

        public async Task<CentroCusto> Update(CentroCusto centroCusto)
        {
            var centroCustoAtualizado =  _repositoryCentroCusto.Update(centroCusto);

            var fila = Enum.GetName(typeof(FilasEnum), FilasEnum.Update).ToString();
            _applicationServicePublisher.EnviarModificacaoCentroCusto(centroCustoAtualizado, fila);

            return centroCustoAtualizado;
        }
    }
}
