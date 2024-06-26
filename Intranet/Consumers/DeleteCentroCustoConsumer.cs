using Intranet.Application.Interfaces;
using Intranet.Models;
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
            //var centroCusto = new CentroCusto()
            //{
            //    Estrutura = context.Message.Estrutura,
            //    Ativo = context.Message.Ativo,
            //    BennerId = context.Message.BennerId,
            //    Nome = context.Message.Nome 
            //};

            _applicationServiceCentroCusto.Delete(context.Message.Estrutura);
            return Task.CompletedTask;
        }
    }
}
