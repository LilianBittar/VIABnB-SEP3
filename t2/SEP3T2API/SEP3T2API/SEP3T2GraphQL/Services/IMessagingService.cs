using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services
{
    public interface IMessagingService
    {
        /// <summary>
        /// Sends a message to the <c>Receiver</c> of the <c>Message</c>
        /// </summary>
        /// <param name="message">Message container the receiver, sender and content of message.
        /// Message cannot be null.  
        /// </param>
        /// <exception href="ArgumentException">If message could not be created</exception>
        /// <exception href="KeyNotFoundException">If Recevier does not exist</exception>
        /// <returns>The sent message</returns>
        public Task<Message> SendMessageAsync(Message message);
        public Task<IEnumerable<Message>> GetMessagesByUserIdAsync(int userId);
    }
}