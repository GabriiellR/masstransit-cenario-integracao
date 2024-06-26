using BennerApi.Application.Interfaces;
using BennerApi.Models;
using MassTransit;
using Messages;

namespace BennerApi.Application
{
    public class ApplicationServicePublisher : IApplicationServicePublisher
    {
        readonly IBus _bus;

        public ApplicationServicePublisher(IBus bus)
        {
            _bus = bus;
        }

        public async void EnviarModificacaoCentroCusto(CentroCusto centroCusto, string fila)
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri($"queue:{fila}"));

            await endpoint.Send<IMessageCentroCusto>(new
            {
                Estrutura = centroCusto.Estrutura,
                Nome = centroCusto.Nome,
                BennerId = centroCusto.BennerId,
                Ativo = centroCusto.Ativo

            });
        }
    }
}
