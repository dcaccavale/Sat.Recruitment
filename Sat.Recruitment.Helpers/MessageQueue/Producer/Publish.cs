using RabbitMQ.Client;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sat.Recruitment.MessageQueue.Publish
{
    public class QueuePublishOptions
    {
        public string Queue { get; set; }
        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public IDictionary<string, object> Arguments { get; set; }
        public string RoutingKey { get; set; }
    }

    public class ExchangePublishOptions {
        public string ExchangeName { get; set; }
        public string ExchangeType { get; set; }
    }

    public class SendOptions{
        public string?  ExchangeName { get; set; }
        public string? RoutingKey { get; set; }
        public IBasicProperties? BasicProperties { get; set; }
    }

    public abstract class Publish {
        public abstract void SourceDeclare(IModel model);
        public virtual void Send(IModel model, SendOptions sendOptions,string messageToSend)
        {
            using (model)
            {
               this.SourceDeclare(model);

                var body = Encoding.UTF8.GetBytes(messageToSend);

                model.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);

            }
        }
    }

    public class PublishExchange : Publish
    {
        private ExchangePublishOptions _options;
        public PublishExchange(ExchangePublishOptions exchangePublishOptions)
        {
            _options = exchangePublishOptions;
        }
        public override void SourceDeclare(IModel model)
        {
            model.ExchangeDeclare(exchange: _options.ExchangeName, type: _options.ExchangeType);

        }
    }
    public class PublishQueue : Publish
    {
        private QueuePublishOptions _options;
        public PublishQueue(QueuePublishOptions queuePublishOptions)
        {
            _options= queuePublishOptions;
        }
        public override void SourceDeclare(IModel model)
        {
            model.QueueDeclare(queue: _options.Queue,
                                   durable: _options.Durable,
                                   exclusive: _options.Exclusive,
                                   autoDelete: _options.AutoDelete,
                                   arguments: _options.Arguments);

        }
    }
}
