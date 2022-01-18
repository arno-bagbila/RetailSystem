using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace Sales
{
   public class PlaceOrderHandler : IHandleMessages<PlaceOrder>
   {
      public async Task Handle(PlaceOrder message, IMessageHandlerContext context)
      {
         //if (random.Next(0, 100) > 80)
         //{
         //   throw new Exception("BOOM");
         //}

         log.Info($"Received PlaceOrder, OrderId = {message.OrderId}");

         await context.Publish(new OrderPlaced { OrderId = message.OrderId });

      }

      private static ILog log = LogManager.GetLogger<PlaceOrderHandler>();
      private static Random random = new Random();

   }
}
