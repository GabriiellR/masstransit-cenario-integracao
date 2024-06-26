using Intranet.Application.Interfaces;
using Intranet.Models;
using MassTransit;
using Messages;

namespace Intranet.Consumers
{
    public class UpdateCentroCustoConsumer : IConsumer<IMessageCentroCusto>
    {
        readonly IApplicationServiceCentroCusto _applicationServiceCentroCusto;

        public UpdateCentroCustoConsumer(IApplicationServiceCentroCusto applicationServiceCentroCusto)
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


            _applicationServiceCentroCusto.Update(centroCusto);
            return Task.CompletedTask;
        }
    }
}
