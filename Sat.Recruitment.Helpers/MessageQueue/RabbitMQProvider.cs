using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Helpers.MessageQueue
{
    public class RabbitMQProvider : IServiceBusProvider
    {
        public void Configure(IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        public void Send(string messageToSend)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendAsync(string messageToSend)
        {
            throw new NotImplementedException();
        }
    }
}
