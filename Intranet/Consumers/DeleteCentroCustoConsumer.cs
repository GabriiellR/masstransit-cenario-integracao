using Intranet.Application.Interfaces;
using MassTransit;
using Messages;

namespace Intranet.Consumers
{
    public class DeleteCentroCustoConsumer : IConsumer<IMessageCentroCusto>
    {
        readonly IApplicationServiceCentroCusto _applicationServiceCentroCusto;


        public DeleteCentroCustoConsumer(IApplicationServiceCentroCusto applicationServiceCentroCusto)
        {
            _applicationServiceCentroCusto = applicationServiceCentroCusto;
        }

        public Task Consume(ConsumeContext<IMessageCentroCusto> context)
        {
            _applicationServiceCentroCusto.Delete(context.Message.Estrutura);
            return Task.CompletedTask;
        }
    }
}
