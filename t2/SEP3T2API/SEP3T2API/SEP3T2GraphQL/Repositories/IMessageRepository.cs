using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IMessageRepository
    {
        public Task<IEnumerable<Message>> GetAllMessagesAsync();
        public Task<Message> CreateMessageAsync(Message message);
    }
}