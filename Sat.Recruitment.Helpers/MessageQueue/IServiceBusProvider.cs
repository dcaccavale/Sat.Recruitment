using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Helpers.MessageQueue
{
    public interface IServiceBusProvider
    {
        
        void Configure(IConfiguration configuration);
        void Send(string messageToSend);
        Task<bool> SendAsync(string messageToSend);
    }
}
