using MassTransit;

namespace Intranet.Consumers
{
    public class CentroCustoConsumer : IConsumer<string>
    {
        public Task Consume(ConsumeContext<string> context)
        {


            throw new NotImplementedException();
        }
    }
}
