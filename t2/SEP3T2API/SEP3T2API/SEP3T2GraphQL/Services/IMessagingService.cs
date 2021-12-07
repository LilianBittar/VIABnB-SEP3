using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IMessagingService
    {
        public Task<Message> SendMessageAsync(Message message);
        public Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int userId);
    }
}