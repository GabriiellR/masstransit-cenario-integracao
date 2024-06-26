using Intranet.Application.Interfaces;
using Intranet.Models;
using MassTransit;
using Messages;

namespace Intranet.Consumers
{
    public class CreateCentroCustoConsumer : IConsumer<IMessageCentroCusto>
    {
        readonly IApplicationServiceCentroCusto _applicationServiceCentroCusto;

        public CreateCentroCustoConsumer(IApplicationServiceCentroCusto applicationServiceCentroCusto)
        {
                _applicationServiceCentroCusto = applicationServiceCentroCusto;
        }

        public Task Consume(ConsumeContext<IMessageCentroCusto> context)
        {
            var centroCusto = new CentroCusto()
            {
                Estrutura = context.Message.Estrutura,
                Ativo = context.Message.Ativo,
                BennerId = context.Message.BennerId,
                Nome = context.Message.Nome
            };

            _applicationServiceCentroCusto.Post(centroCusto);
            return Task.CompletedTask;
        }
    }
}
