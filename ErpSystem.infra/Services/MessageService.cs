using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Services
{
    public class MessageService : IMessageService
    {

        IMessageRepository _repository;
        public MessageService(IMessageRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Delete(decimal id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<ChatMessageDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Message> GetById(decimal id)
        {
            return await _repository.GetById(id);
        }

        public async Task<List<Message>> GetConversation(ConversationDTO conversationDTO)
        {
            return await _repository.GetConversation(conversationDTO);
        }

        public async Task<List<Message>> GetMessages(decimal employeeId)
        {
            return await _repository.GetMessages(employeeId);
        }

        public async Task<int> Insert(Message message)
        {
            return await _repository.Insert(message);
        }

        public async Task<int> Update(Message message)
        {
            return await _repository.Update(message);
        }
    }
}
