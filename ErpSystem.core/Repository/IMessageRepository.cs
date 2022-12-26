using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.core.Repository
{
    public interface IMessageRepository
    {
        public Task<int> Insert(Message message);
        public Task<int> Update(Message message);
        public Task<int> Delete(decimal id);
        public Task<List<ChatMessageDTO>> GetAll();
        public Task<Message> GetById(decimal id);
        public Task<List<Message>> GetMessages(decimal employeeId);
        public Task<List<Message>> GetConversation(ConversationDTO conversationDTO);
    }
}
