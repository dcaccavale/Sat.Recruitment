using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;

namespace Sat.Recruitment.Helpers.MessageQueue
{
    public class ChannelFactory 
    {
        private IModel _channel;
        public ChannelFactory(IConfiguration configuration)
        {
           
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            _channel = connection.CreateModel();
        }
        public IModel Channel()
        {
            return _channel;
        }
    }
}
