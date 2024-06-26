using BennerApi.Application.Interfaces;
using BennerApi.CrossCutting;
using BennerApi.Models;
using BennerApi.Repository.Interfaces;
using MassTransit;

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
            return _repositoryCentroCusto.Post(centroCusto);
        }

        public async Task<CentroCusto> Update(CentroCusto centroCusto)
        {
            return _repositoryCentroCusto.Update(centroCusto);
        }
    }
}
