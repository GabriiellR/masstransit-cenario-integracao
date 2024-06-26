using BennerApi.Models;

namespace BennerApi.Application.Interfaces
{
    public interface IApplicationServicePublisher
    {
        void EnviarModificacaoCentroCusto(CentroCusto centroCusto, string fila);
    }
}
