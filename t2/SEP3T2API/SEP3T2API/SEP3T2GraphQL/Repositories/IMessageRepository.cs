using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Repositories
{
    public interface IMessageRepository
    {
        /// <summary>
        /// Get a list of Message objects via API
        /// </summary>
        /// <returns>A list of Message objects</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<IEnumerable<Message>> GetAllMessagesAsync();
        /// <summary>
        /// Create a new Message object via API
        /// </summary>
        /// <param name="message">The new Message</param>
        /// <returns>The newly created Message object</returns>
        /// <exception cref="System.Exception">Thrown if the API response is not successful</exception>
        public Task<Message> CreateMessageAsync(Message message);
    }
}